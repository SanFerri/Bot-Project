using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    abstract class AbstractHandlerRespuestas
    {
        private IHandlerRespuestas _nextHandler; 
        public IHandlerRespuestas SetNext(IHandlerRespuestas handler)
        {
            this._nextHandler = handler;

            return handler;
        }

        public virtual object Handle(IUsuario usuario, string message)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(usuario, message);
            }
            else
            {
                return null;
            }
        }
    }
}