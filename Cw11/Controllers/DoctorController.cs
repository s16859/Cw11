using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cw11.Models;
using Cw11.DTOs;

namespace Cw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalContext _context;

        public DoctorController(HospitalContext context)
        {
            this._context = context;
        }


        [HttpGet("{id}")]
        public IActionResult Doctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+id);
            }

            return Ok(doctor);
        }


        [HttpPost]
        public IActionResult Doctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor();

            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Email = doctorDTO.Email;

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpPut]
        public IActionResult UpdateDoctor(DoctorDTO doctorDTO)
        {

            Doctor doctor = _context.Doctors.Find(Int32.Parse(doctorDTO.IdDoctor));

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+doctorDTO.IdDoctor);
            }

            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Email = doctorDTO.Email;

            _context.Update(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound("Nie znaleziono doctora o id = "+id);
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            

            return Ok();
        }
    }
}
