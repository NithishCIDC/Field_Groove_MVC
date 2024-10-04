﻿using Feild_Groove.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Groove.Application.Interfaces
{
	public interface IUserRepository
	{
		public Task<string> Create(RegisterModel entity);
		public Task<string> IsValidUser(LoginModel entity);
	}
}