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

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}