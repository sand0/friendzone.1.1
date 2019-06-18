using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public ICategoryService CategoryService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult All()
        {
            return Ok(CategoryService.GetAllCategories());
        }

        [HttpPost("[action]/")]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = category.Id == 0 ?
                    await CategoryService.CreateAsync(category) :
                    await CategoryService.EditAsync(category);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("[action]/")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                OperationDetails result = await CategoryService.DeleteAsync(id);
                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}