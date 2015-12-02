using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeCompany.FizzBussinator
{
    public class FizzBuzzinator
    {
        //Default config
        private readonly IDictionary<int, string> _defaultConfig = new Dictionary<int, string>() { { 3, "fizz" }, { 5, "buzz" } };
        private readonly IDictionary<int, string> _runtimeConfig;

        public FizzBuzzinator(IDictionary<int, string> config = null)
        {
            _runtimeConfig = config ?? _defaultConfig;
        }

        public string Fizzer(int number)
        {
            IEnumerable<KeyValuePair<int, string>> configs = _runtimeConfig.Where(x => number%x.Key == 0);

            if (configs == null || !configs.Any())
                return number.ToString();

            return string.Concat(configs.Select(x => x.Value));
        }
    }
}