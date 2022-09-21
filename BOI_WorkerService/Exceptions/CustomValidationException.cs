﻿using FluentValidation.Results;

namespace BOI_WorkerService.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public CustomValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
