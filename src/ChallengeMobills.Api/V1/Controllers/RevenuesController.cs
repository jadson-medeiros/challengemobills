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
    [Route("api/v{version:apiVersion}/revenues")]
    public class RevenuesController : MainController
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IRevenueService _revenueService;
        private readonly IMapper _mapper;

        public RevenuesController(IRevenueRepository revenueRepository, IMapper mapper,
            IRevenueService revenueService, INotify notify, IUser user) : base(notify, user)
        {
            _revenueRepository = revenueRepository;
            _mapper = mapper;
            _revenueService = revenueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RevenueViewModel>>> GetAll()
        {
            var revenue = _mapper.Map<IEnumerable<RevenueViewModel>>(await _revenueRepository.GetAll());

            return Ok(revenue);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RevenueViewModel>> GetExpenseById(Guid id)
        {
            var revenue = _mapper.Map<RevenueViewModel>(await _revenueRepository.GetById(id));

            if (revenue == null) return NotFound();

            return Ok(revenue);
        }

        [HttpGet("getBalance")]
        public async Task<ActionResult<decimal>> GetBalance()
        {
            var expenses = GetBalance(_mapper.Map<IEnumerable<Revenue>>(await _revenueRepository.GetAll()));

            return Ok(expenses);
        }

        [HttpPost]
        public async Task<ActionResult<RevenueViewModel>> Insert(RevenueViewModel revenueViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var revenue = _mapper.Map<Revenue>(revenueViewModel);
            await _revenueService.Insert(revenue);

            return CustomResponse(revenueViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<RevenueViewModel>> Update(Guid id, RevenueViewModel revenueViewModel)
        {
            if (id != revenueViewModel.Id) return CustomResponse(ModelState);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var revenue = _mapper.Map<Revenue>(revenueViewModel);
            await _revenueService.Update(revenue);

            return CustomResponse(revenueViewModel);
        }

        [HttpDelete("{id:guid})")]
        public async Task<ActionResult<RevenueViewModel>> Delete(Guid id)
        {
            var revenueViewModel = _mapper.Map<RevenueViewModel>(await _revenueRepository.GetById(id));

            if (revenueViewModel == null) return NotFound();

            await _revenueService.Delete(id);

            return CustomResponse();
        }

        public decimal GetBalance(IEnumerable<Revenue> revenues)
        {
            decimal balance = 0;
            foreach (var item in revenues.Select(o => o.Value)) balance += item;
            return balance;
        }
    }
}
