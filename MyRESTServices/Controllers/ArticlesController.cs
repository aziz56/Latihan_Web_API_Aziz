using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRestServices.BLL.Interfaces;
using MyRestServices.BLL.DTOs;

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;

        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;

        }
        [HttpGet]
        public  async Task<IEnumerable<ArticleDTO>> Get()
        {
            var results = await _articleBLL.GetAll();
            return results;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _articleBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ArticleCreateDTO articleCreateDTO)
        {
            if (articleCreateDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _articleBLL.Insert(articleCreateDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ArticleUpdateDTO articleUpdateDTO)
        {
            if (await _articleBLL.GetById(id) == null)
            {
                return NotFound();
            }
            try
            {
                var result = await _articleBLL.Update(id, articleUpdateDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
        }
        public async Task<IActionResult>Delete(int id)
        {
            if (await _articleBLL.GetById(id) == null)
            {
                return NotFound();
            }
            try
            {
                await _articleBLL.Delete(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
