﻿namespace Beam.Shared.Responses
{
    public record ErrorResponse
    {
        public string ErrorMessage { get; init; } 
        public string StackTrace { get; init; }

   
        public ErrorResponse(string errorMessage,string stackTrace)
        {
            ErrorMessage = errorMessage;
            
        }
   
    };
}