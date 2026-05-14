using Microsoft.AspNetCore.Mvc;

using Bank.Data;
using Bank.Model;
using Bank.depDto;using Bank.wtdDto;

namespace Bank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class bankController : ControllerBase
    {
        private readonly AppDbContext _context;
        public bankController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult getAllaccounts(){
            return Ok(_context.Accounts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult getUser(int id)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (acc == null)
                return NotFound("User Not Found");
            return Ok(acc);
        }

        [HttpPost("create")]
        public IActionResult createUser(BankAccount newUser)
        {
            _context.Accounts.Add(newUser);
            _context.SaveChanges();
            return Ok(newUser);
        }

        [HttpPost("deposit/{id}")]
        public IActionResult deposit(depositDto depo, int id)
        {
            var dep = depo.depos;
            var u = _context.Accounts.FirstOrDefault(a => a.Id ==id);
            if (u ==null)
                return BadRequest();
            u.Balance += dep;
            _context.SaveChanges();
            return Ok("Current Balance: "+u.Balance);
        }

        [HttpPost("withdraw/{id}")]
        public IActionResult withdraw(wdthDto wwdt, int id)
        {   
            var wdt = wwdt.wdt;
            var u = _context.Accounts.FirstOrDefault(a => a.Id ==id);
            if (u ==null)
                return BadRequest();
            if (u.Balance < wdt)
                return BadRequest();
            u.Balance -= wdt;
            _context.SaveChanges();
            return Ok("Current Balance: "+u.Balance);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.Id == id);
            if (acc == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(acc);
            _context.SaveChanges();

            return NoContent();
        }

    }
}