using AutoMapper;
using ChallengeMobills.Api.Controllers;
using ChallengeMobills.Api.ViewModels;
using ChallengeMobills.Business.Intefaces;
using ChallengeMobills.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeMobills.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/expenses")]
    public class ExpensesController : MainController
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseRepository expenseRepository, IMapper mapper,
            IExpenseService expenseService, INotify notify, IUser user) : base(notify, user)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseViewModel>>> GetAll()
        {
            var expenses = _mapper.Map<IEnumerable<ExpenseViewModel>>(await _expenseRepository.GetAll());

            return Ok(expenses);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ExpenseViewModel>> GetExpenseById(Guid id)
        {
            var expense = _mapper.Map<ExpenseViewModel>(await _expenseRepository.GetById(id));

            if (expense == null) return NotFound();

            return Ok(expense);
        }

        [HttpGet("getBalance")]
        public async Task<ActionResult<decimal>> GetBalance()
        {
            var expenses = GetBalance(_mapper.Map<IEnumerable<ExpenseViewModel>>(await _expenseRepository.GetAll()));

            return Ok(expenses);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseViewModel>> Insert(ExpenseViewModel expenseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var expense = _mapper.Map<Expense>(expenseViewModel);
            await _expenseService.Insert(expense);

            return CustomResponse(expenseViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ExpenseViewModel>> Update(Guid id, ExpenseViewModel expenseViewModel)
        {
            if (id != expenseViewModel.Id) return CustomResponse(ModelState);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var expense = _mapper.Map<Expense>(expenseViewModel);
            await _expenseService.Update(expense);

            return CustomResponse(expenseViewModel);
        }

        [HttpDelete("{id:guid})")]
        public async Task<ActionResult<ExpenseViewModel>> Delete(Guid id)
        {
            var expenseViewModel = _mapper.Map<ExpenseViewModel>(await _expenseRepository.GetById(id));

            if (expenseViewModel == null) return NotFound();

            await _expenseService.Delete(id);

            return CustomResponse();
        }

        public decimal GetBalance(IEnumerable<ExpenseViewModel> expense)
        {
            decimal balance = 0;
            foreach (var item in expense.Select(o => o.Value)) balance += item;
            return balance;
        }
    }
}
