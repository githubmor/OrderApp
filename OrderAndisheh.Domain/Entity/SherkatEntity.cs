﻿using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class SherkatEntity
    {
        public SherkatEntity(string sherkatName)
        {
            if (string.IsNullOrEmpty(sherkatName))
            {
                throw new ArgumentNullException("نام شركت نمي تواند تهي باشد");
            }
            SherkatName = sherkatName;
        }

        public string SherkatName { get; private set; }
    }
}