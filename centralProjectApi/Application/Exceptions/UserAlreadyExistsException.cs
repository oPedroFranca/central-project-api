using System;

namespace centralProjectApi.Application.Exceptions
{
    // Exceção personalizada para o caso de email já registrado
    public class UserAlreadyExistsException : Exception
    {
        // Construtor que recebe a mensagem personalizada
        public UserAlreadyExistsException(string message)
            : base(message)
        {
        }

        // Construtor que também recebe a mensagem e uma exceção interna (para encadeamento de exceções)
        public UserAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}