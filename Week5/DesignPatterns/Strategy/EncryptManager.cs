using System;
using System.Collections.Generic;
using System.Text;

namespace ExStrategy
{
    class EncryptManager
    {
        private ReadFile _strategy;

        public EncryptManager(ReadFile strategy)
        {
            this._strategy = strategy;
        }

        public void Process()
        {
            this._strategy.Process();
        }
    }
}
