<Query Kind="Statements" />

//var startCondition = "3,4,3,1,2";
var startCondition = "1,1,1,1,3,1,4,1,4,1,1,2,5,2,5,1,1,1,4,3,1,4,1,1,1,1,1,1,1,2,1,2,4,1,1,1,1,1,1,1,3,1,1,5,1,1,2,1,5,1,1,1,1,1,1,1,1,4,3,1,1,1,2,1,1,5,2,1,1,1,1,4,5,1,1,2,4,1,1,1,5,1,1,1,1,5,1,3,1,1,4,2,1,5,1,2,1,1,1,1,1,3,3,1,5,1,1,1,1,3,1,1,1,4,1,1,1,4,1,4,3,1,1,1,4,1,2,1,1,1,2,1,1,1,1,5,1,1,3,5,1,1,5,2,1,1,1,1,1,4,4,1,1,2,1,1,1,4,1,1,1,1,5,3,1,1,1,5,1,1,1,4,1,4,1,1,1,5,1,1,3,2,2,1,1,1,4,1,3,1,1,1,2,1,3,1,1,1,1,4,1,1,1,1,2,1,4,1,1,1,1,1,4,1,1,2,4,2,1,2,3,1,3,1,1,2,1,1,1,3,1,1,3,1,1,4,1,3,1,1,2,1,1,1,4,1,1,3,1,1,5,1,1,3,1,1,1,1,5,1,1,1,1,1,2,3,4,1,1,1,1,1,2,1,1,1,1,1,1,1,3,2,2,1,3,5,1,1,4,4,1,3,4,1,2,4,1,1,3,1";

var fishes = startCondition.Split(",").Select(v => short.Parse(v)).ToList();

var states = Enumerable.Range(0, 9).ToDictionary(s => s, s => new FishesPerState(s, fishes.Count(f => f == s)));
//states.Dump(); // condition initiale ok
("0 " + states.Select(c => c.Value.Counter).Sum()).Dump();

for (int iDay = 1; iDay <= 256; iDay++)
{
	var copy = states.ToDictionary(s => s.Key, v => new FishesPerState(v.Key, v.Value.Counter));
	foreach (var state in states.Values)
	{
		if (state.State == 0) // is "reset" state
		{
			copy[6].Counter += state.Counter; // reset current fish by setting its state to 6
			copy[8].Counter += state.Counter; // create a new fish
		}
		else
		{
			copy[state.State - 1].Counter += state.Counter; // increase lower state counter
		}
		copy[state.State].Counter -= state.Counter; // remove fish from current state
	}
	states = copy;

	(iDay + " " + states.Select(c => c.Value.Counter).Sum()).Dump();
	//states.Dump();
}

states.Select(c => c.Value.Counter).Sum().Dump();

class FishesPerState
{
	public FishesPerState(int state, long counter)
	{
		State = state;
		Counter = counter;
	}
	public int State { get; set; }
	public long Counter { get; set; }
}