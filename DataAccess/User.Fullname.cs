﻿namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        //private string _nameFull;

        public string NameFull
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}
