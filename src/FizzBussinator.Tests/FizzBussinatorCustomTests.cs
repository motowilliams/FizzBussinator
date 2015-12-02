using System;
using System.Collections.Generic;
using Should;
using Xunit;
using Xunit.Abstractions;

namespace AcmeCompany.FizzBussinator.Tests
{
    public class FizzBussinatorCustomTests
    {
        private readonly ITestOutputHelper output;
        private FizzBuzzinator fizzBuzzinator;

        public FizzBussinatorCustomTests(ITestOutputHelper output)
        {
            this.output = output;
            fizzBuzzinator = new FizzBuzzinator(new Dictionary<int, string>()
            {
                { 3, "fizz" },
                { 5, "buzz" },
                { 7, "foo" },
                { 8, "bar" },
            });
        }

        [Fact]
        public void should_return_one_for_fizzbuzzless_input()
        {
            string result = fizzBuzzinator.Fizzer(1);

            result.ShouldEqual("1");
        }

        [Fact]
        public void should_return_fizz_for_fizz_input()
        {
            string result = fizzBuzzinator.Fizzer(3);

            result.ShouldEqual("fizz");
        }

        [Fact]
        public void should_return_buzz_for_buzz_input()
        {
            string result = fizzBuzzinator.Fizzer(5);

            result.ShouldEqual("buzz");
        }

        [Fact]
        public void should_return_foo_for_foo_input()
        {
            string result = fizzBuzzinator.Fizzer(7);

            result.ShouldEqual("foo");
        }

        [Fact]
        public void should_return_bar_for_foo_input()
        {
            string result = fizzBuzzinator.Fizzer(8);

            result.ShouldEqual("bar");
        }

        [Fact]
        public void should_return_fizzbuzz_for_fizzbuzz_input()
        {
            string result = fizzBuzzinator.Fizzer(15);

            result.ShouldEqual("fizzbuzz");
        }

        [Theory, MemberData("FizzTestData")]
        public void should_run_dataset(int number, string message)
        {
            fizzBuzzinator.Fizzer(number).ShouldEqual(message);
        }

        public static IEnumerable<object> FizzTestData()
        {
            return new List<object[]>
            {
                new object[] { 1,"1" },
                new object[] { 2,"2" },
                new object[] { 3,"fizz" },
                new object[] { 4,"4" },
                new object[] { 5,"buzz" },
                new object[] { 6,"fizz" },
                new object[] { 7,"foo" },
                new object[] { 8,"bar" },
                new object[] { 9,"fizz" },
                new object[] { 10,"buzz" },
                new object[] { 11,"11" },
                new object[] { 12,"fizz" },
                new object[] { 13,"13" },
                new object[] { 14,"foo" },
                new object[] { 15,"fizzbuzz" },
                new object[] { 16,"bar" },
                new object[] { 17,"17" },
                new object[] { 18,"fizz" },
                new object[] { 19,"19" },
                new object[] { 20,"buzz" },
                new object[] { 21,"fizzfoo" },
                new object[] { 22,"22" },
                new object[] { 23,"23" },
                new object[] { 24,"fizzbar" },
                new object[] { 25,"buzz" },
                new object[] { 26,"26" },
                new object[] { 27,"fizz" },
                new object[] { 28,"foo" },
                new object[] { 29,"29" },
                new object[] { 30,"fizzbuzz" },
                new object[] { 31,"31" },
                new object[] { 32,"bar" },
                new object[] { 33,"fizz" },
                new object[] { 34,"34" },
                new object[] { 35,"buzzfoo" },
                new object[] { 36,"fizz" },
                new object[] { 37,"37" },
                new object[] { 38,"38" },
                new object[] { 39,"fizz" },
                new object[] { 40,"buzzbar" },
                new object[] { 41,"41" },
                new object[] { 42,"fizzfoo" },
                new object[] { 43,"43" },
                new object[] { 44,"44" },
                new object[] { 45,"fizzbuzz" },
                new object[] { 46,"46" },
                new object[] { 47,"47" },
                new object[] { 48,"fizzbar" },
                new object[] { 49,"foo" },
                new object[] { 50,"buzz" },
                new object[] { 51,"fizz" },
                new object[] { 52,"52" },
                new object[] { 53,"53" },
                new object[] { 54,"fizz" },
                new object[] { 55,"buzz" },
                new object[] { 56,"foobar" },
                new object[] { 57,"fizz" },
                new object[] { 58,"58" },
                new object[] { 59,"59" },
                new object[] { 60,"fizzbuzz" },
                new object[] { 61,"61" },
                new object[] { 62,"62" },
                new object[] { 63,"fizzfoo" },
                new object[] { 64,"bar" },
                new object[] { 65,"buzz" },
                new object[] { 66,"fizz" },
                new object[] { 67,"67" },
                new object[] { 68,"68" },
                new object[] { 69,"fizz" },
                new object[] { 70,"buzzfoo" },
                new object[] { 71,"71" },
                new object[] { 72,"fizzbar" },
                new object[] { 73,"73" },
                new object[] { 74,"74" },
                new object[] { 75,"fizzbuzz" },
                new object[] { 76,"76" },
                new object[] { 77,"foo" },
                new object[] { 78,"fizz" },
                new object[] { 79,"79" },
                new object[] { 80,"buzzbar" },
                new object[] { 81,"fizz" },
                new object[] { 82,"82" },
                new object[] { 83,"83" },
                new object[] { 84,"fizzfoo" },
                new object[] { 85,"buzz" },
                new object[] { 86,"86" },
                new object[] { 87,"fizz" },
                new object[] { 88,"bar" },
                new object[] { 89,"89" },
                new object[] { 90,"fizzbuzz" },
                new object[] { 91,"foo" },
                new object[] { 92,"92" },
                new object[] { 93,"fizz" },
                new object[] { 94,"94" },
                new object[] { 95,"buzz" },
                new object[] { 96,"fizzbar" },
                new object[] { 97,"97" },
                new object[] { 98,"foo" },
                new object[] { 99,"fizz" },
                new object[] { 100,"buzz" },
                new object[] { 101,"101" },
                new object[] { 102,"fizz" },
                new object[] { 103,"103" },
                new object[] { 104,"bar" },
                new object[] { 105,"fizzbuzzfoo" },
                new object[] { 106,"106" },
                new object[] { 107,"107" },
                new object[] { 108,"fizz" },
                new object[] { 109,"109" },
                new object[] { 110,"buzz" },
            };
        }
    }
}