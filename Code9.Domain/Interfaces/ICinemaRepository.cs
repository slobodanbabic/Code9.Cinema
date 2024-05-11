﻿using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();

        public void UpdateCinema(Cinema cinema);
        public  Task<Cinema> AddCinema(Cinema cinema);
    }
}
