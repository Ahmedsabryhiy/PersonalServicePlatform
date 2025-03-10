﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public  class DataAccessException : Exception
    {
        public DataAccessException(Exception ex, string CustomMessage, ILogger logger)
        {
            logger.LogError($"main exception {ex.Message} " +
                $" developer custom exception {CustomMessage} "
                );

        }
    }
}
