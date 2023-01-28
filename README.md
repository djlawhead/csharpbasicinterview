# C# Sample Problems

## About

This repo contains a couple different projects and their tests. Each project represents a different problem to solve.

Every project has a sibling test project, with the suffix `Tests`. The goal is to write code such that all the tests pass. Note that not all possible tests may have been provided for you, because part of the exercise is to demonstrate your knowledge of [Test Driven Design (TDD).](https://www.agilealliance.org/glossary/tdd/) A good rule of the thumb for these exercises is to observe what is being asked of you, and see if a test exists. If it doesn't, begin by writing a test that demonstrates the working solution, then write the actual solution.

### Test Driven Design: An Example

If a project asks of you to add two numbers together, start by writing a test case that uses code which has yet to be written. In the new test case, assert that two specific numbers equal an expected outputted number (e.g. `2 + 2 = 4`). Once you've written athe test case demonstrating your understanding of the problem, write the actual algorithm that sums the numbers.

```C#
[Test]
public void Given_NumbersTwoAndTwo_Then_SumEqualsFour()
{
    // 1. Arrange
    const int expectation = 4;
    var sut = new Summable(); // 'sut' means Subject Under Test
    
    // 2. Act
    int result = sut.Add(2, 2);
    
    // 3. Assert
    Assert.Equals(result, expectation);
}
```

Unit tests typically have three phases: Arrange, act, and assert. Arrange is where you prepare any requirements needed for the test to run, such as setting up expectations and preparing the Subject Under Test (`sut`, or, the thing being tested). The act phase is where the actual Subject Under Test is executed, and perhaps any output is stored for comparison in the last stage. That last stage is called assert. This is where you make assertions regarding what the Subject Under Test has done. In your case, you wish to assert that adding two numbers yields expected output. In this case, you're asserting two and two make four. (Quite the assertion, if I may say so myself.)

The particular test case demonstrated above will fail. This is because there is code being executed that has not yet been written. `Summable` does not yet exist! The requirements were to create a piece of software that can add two numbers together, so that was what was tested, even if nothing existed to actually do the task (yet).  After writing the test case, our next logical step is to write the code that will allow the test to pass, which means implementing `Summable`, and its API. Easy, since it only consists of the method `Add(int, int)`. Once that is accomplished, the test will pass.

### Okay, I get it. But why?

Like a bad stand-up comedian, this all seemed like a lot of set up for a really weak punchline. Write the test case, consisting of arranging the subject, acting on code that doesn't exist yet, and making a bunch of assertions based on entirely fictional output. Real [enterprise-y](https://www.urbandictionary.com/define.php?term=enterprise%20code), huh? 

Other than impressing the "hands on" middle managers of the world, what does this really accomplish? 

One of the major tenants of any agile management philosophy (such as Scrum, Kanban, etc.), is _relentless improvement._ To accomplish this, the team responsible for the software must be able to demonstrate the quality and stability of their work. We need a solid metric for that relentless improvement. We can't just guess! Unit tests offer an easy way for teams to assess that _individual units of work_ are functioning the way they are supposed to. This is particularly important in large corporations where dozens of developers might touch a single code base. 

Imagine a new early career dev decides that your work on `Summable` just isn't cool enough. Yeah, you might have ten years under your belt, but you haven't heard about this really cool new design pattern that everyone in the Bay Area is using. Go import some Excel spreadsheets, old timer! Well, this young whippersnapper not only made `Summable` really hip, but they also managed to break all of your hard work in an impressively specacular fashion. (Trust me, you'll witness code that will make you want to eat your keyboard, that was written by individuals who believe their intellect is a cosmic abnormality.)

Well, good thing your unit tests started breaking immediatly. A good team will have put safeties in place that prevent code with failing unit tests from being merged into the mainline. 

There are many other techniques that can be utilized to ensure the stability and quality of work. However, they are often used in combination with unit tests. 

## The goal of the exercises 

Remember that the goal here isn't to get the solution exactly right, but to be able to flex your knowledge of C#, unit tests, and Test Driven Development. Be sure to ask questions! If you don't understand a project's requirements, that usually means they weren't written very well. This happens a lot more often than not! Do the best you can and most importantly, demonstrate your work through test cases. Don't focus on getting things done in a particular timeframe. This is the world of software, where discovery is the goal, and the unexpected is anticipated (despite what the project manager might otherwise say).

[Inspect, adapt, and repeat!](https://www.scrum.org/resources/blog/three-pillars-empiricism-scrum)

([Scrum teams](https://www.scrum.org/resources/what-is-scrum/) agree on how long individual sprints should be. A common timeframe is two weeks, which means the team comes together and assess what can be accomplished in two weeks. This is referred to as the team's capacity, and is always improved upon. Remember, empiricism is they most important practice a team can have.)

### Scrum

The fundamentals of these projects are based on a software management framework called Scrum, an agile management philosophy. To read more about it, visit [https://scrum.org](https://scrum.org). You don't need to know anything about Scrum, but reading up on it can't hurt, especially if you're going into interviews in a company known for using it. It has pretty much been the way forward in the world of enterprise software for a good number of years. It has proven so successful, that companies that fail to implement it (and any agile philosophy at all) are very likely to fail to meet their goals. A great read is "Doing Twice the Work in Half the Time."

## A humble warning

I have left out some things on purpose. Clever interviewers might do this to see if you can fill in the gaps, and with what! (I might also be lazy.) I will fully admit that sometimes I may have left out just a bit too much. Feel free to get in touch with me if the directions are unclear, or even if you're just stuck! Relentless improvement, right? :)

## The Projects

The general layout of each project will follow these conventions:

| Path                                     | Purpose                                         |
|:-----------------------------------------|:------------------------------------------------|
| `./MyCoolProjectTests/UnitTests.cs`      | Unit tests for the project. This is your starting point! |
| `./MyCoolProject/`                       | This area contains all of the code you must implement.   |

Now, let's talk about the requirements for each project!

### 1. Discount Calculator

Daniel's Kingdom of Carbs is a world famous bakery that is known for often having discounts on its various delicious (and strikingly unhealthy) goods. They've contracted you to write some software that will determine if a discount applies based on the items being purchased. There may even be some free cookies in it for you. 

#### Acceptance Criteria

As a system, I must accept a sequence of product codes in order to determine if those products together may have a discount applied to them. A product code is a single alphanumeric character.

#### Product Codes

| Product Code | Price  | Discount                                  |
|:-------------|:-------|:------------------------------------------|
| A            | $2.00  | Four for $6.00                            |
| B            | $6.00  | Half dozen for $10.00                     |
| C            | $12.00 | No discount.                              |
| D            | $18.00 | -$2.00 when combined with at least one C. |
| F            | $30.00 | Buy one, get one free!                    |

### 2. Furniture Parts

Dåniel Fürnitüre is a world-renounced (sic) manufacturer that provides some of the best and most trendy particle board furniture available on the market. Right now they're nearing the release of a highly anticipated inventory management system that is guaranteed to increase sales across the board. By how much nobody really knows, since management doesn't preactice empiricism very well, if at all.

#### Acceptance Criteria

As an inventory management professional, I would like to be able to get all the parts required to build a particular piece of furniture. Each part code should contain alphanumeric characters and be globally unique. Some products share the same parts, and those part codes should be the same across all products.

Additionally, part codes should be:

1. No longer than five characters long,
2. Be suffixed with the last two characters of the product they belong to, and,
3. Be prefixed with 'D' if they do not belong to a product.

#### Where's the project?

One of the developers on your team was offered a better pay at another firm, and only managed to get the skeleton of the unit tests written up. It's up to you to complete the rest of the project (see section 'The Projects' above on how the directory structure is anticipated to look like). Look at how the unit tests are written to gain some insight into the architectual approach that was anticipated by the original developer. Looks like they were fond of factories.

### Mysterious Numbers

You've been given the lead on a new, highly advanced cryptography project for an esteemed security firm. They claim that using simple arithemtic, they can encrypt nearly anything using an uncrackable algorithm. The only problem is that they haven't figured out how to actually add numbers yet.

#### Acceptance Criteria

As a system, I should take as input an array of integers and a target number. Two of those integers, when summed up, should equal that target. I need to return the array indices of the two numbers that create the target sum. 