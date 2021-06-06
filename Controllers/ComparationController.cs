using DemoCQRSvsSevrice.Commands;
using DemoCQRSvsSevrice.Models;
using DemoCQRSvsSevrice.Queries;
using DemoCQRSvsSevrice.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoCQRSvsSevrice.Controllers
{
    public class ComparationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public ComparationController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Service

        public IActionResult UsersListByService()
        {
            var watch = Stopwatch.StartNew();
            var users = _userService.GetAllUsers();
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = users,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        public IActionResult UserByService(int id)
        {
            var watch = Stopwatch.StartNew();
            var user = _userService.GetUserById(id);
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = user,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        [HttpPost]
        public IActionResult CreateUserByService(User model)
        {
            var watch = Stopwatch.StartNew();
            _userService.InsertUser(model);
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        [HttpPost]
        public IActionResult UpdateUserByService(User model)
        {
            var watch = Stopwatch.StartNew();
            _userService.UpdateUser(model);
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = model,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }
        
        public IActionResult DeleteService(int id)
        {
            var watch = Stopwatch.StartNew();
            var user = _userService.GetUserById(id);
            if (user != null)
                _userService.DeleteUser(user);
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = user,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        public IActionResult UsersSelectByService() => PartialView("~/Views/Comparation/Shared/_UserSelect.cshtml", _userService.GetAllUsers());

        public IActionResult UserFormByService(int id) => PartialView("~/Views/Comparation/Shared/_UserForm.cshtml", _userService.GetUserById(id));

        #endregion

        #region CQRS

        public async Task<IActionResult> UsersListByCQRS()
        {
            var watch = Stopwatch.StartNew();
            var users = await _mediator.Send(new GetUsersListQuery());
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = users,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        public async Task<IActionResult> UserByCQRS(int id)
        {
            var watch = Stopwatch.StartNew();
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = user,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserByCQRS(User model)
        {
            var watch = Stopwatch.StartNew();
            var user = await _mediator.Send(new InsertUserCommand(model));
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserByCQRS(User model)
        {
            var watch = Stopwatch.StartNew();
            var user = await _mediator.Send(new UpdateUserCommand(model));
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = model,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        public async Task<IActionResult> DeleteUserByCQRS(int id)
        {
            var watch = Stopwatch.StartNew();
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user != null)
                user = await _mediator.Send(new DeleteUserCommand(user));
            watch.Stop();

            var userComparationModel = new UserComparationModel
            {
                Data = user,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            };

            return PartialView("~/Views/Comparation/Shared/_UserComparation.cshtml", userComparationModel);
        }

        public async Task<IActionResult> UsersSelectByCQRS() => PartialView("~/Views/Comparation/Shared/_UserSelect.cshtml", await _mediator.Send(new GetUsersListQuery()));

        public async Task<IActionResult> UserFormByCQRS(int id) => PartialView("~/Views/Comparation/Shared/_UserForm.cshtml", await _mediator.Send(new GetUserByIdQuery(id)));

        #endregion
    }
}
