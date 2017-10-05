﻿using HomeMyDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMyDay.Repository
{
    public interface IPageRepository
    {
		/// <summary>
		/// Gets the latest suprise.
		/// </summary>
		Page GetSuprise();
		void EditPage(string pageid, Page page);
	}
}
