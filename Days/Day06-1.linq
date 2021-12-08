<Query Kind="Statements" />

//var startCondition = "3,4,3,1,2";
var startCondition = "1,1,1,1,3,1,4,1,4,1,1,2,5,2,5,1,1,1,4,3,1,4,1,1,1,1,1,1,1,2,1,2,4,1,1,1,1,1,1,1,3,1,1,5,1,1,2,1,5,1,1,1,1,1,1,1,1,4,3,1,1,1,2,1,1,5,2,1,1,1,1,4,5,1,1,2,4,1,1,1,5,1,1,1,1,5,1,3,1,1,4,2,1,5,1,2,1,1,1,1,1,3,3,1,5,1,1,1,1,3,1,1,1,4,1,1,1,4,1,4,3,1,1,1,4,1,2,1,1,1,2,1,1,1,1,5,1,1,3,5,1,1,5,2,1,1,1,1,1,4,4,1,1,2,1,1,1,4,1,1,1,1,5,3,1,1,1,5,1,1,1,4,1,4,1,1,1,5,1,1,3,2,2,1,1,1,4,1,3,1,1,1,2,1,3,1,1,1,1,4,1,1,1,1,2,1,4,1,1,1,1,1,4,1,1,2,4,2,1,2,3,1,3,1,1,2,1,1,1,3,1,1,3,1,1,4,1,3,1,1,2,1,1,1,4,1,1,3,1,1,5,1,1,3,1,1,1,1,5,1,1,1,1,1,2,3,4,1,1,1,1,1,2,1,1,1,1,1,1,1,3,2,2,1,3,5,1,1,4,4,1,3,4,1,2,4,1,1,3,1";

var fishes = startCondition.Split(",").Select(v => short.Parse(v)).ToList();

("0 " + fishes.Count()).Dump();

for (int iDay = 1; iDay <= 80; iDay++)
{
	int newFishes = 0;
	for (int iFish = 0; iFish < fishes.Count; iFish++)
	{
		var newValue = fishes[iFish] - 1;
		if (newValue < 0)
		{
			newValue = 6;
			newFishes++;
		}
		fishes[iFish] = (short)newValue;
	}

	while (newFishes > 0)
	{
		fishes.Add(8);
		--newFishes;
	}

	(iDay + " " + fishes.Count()).Dump();
	//("Result :					" + string.Join(",", fishes.Select(s => s.Value)) + Environment.NewLine +
	// "Expected  :		" + correction.Split(Environment.NewLine)[iDay + 1] + Environment.NewLine)
	// .Dump();
}

string.Join(",", fishes.Select(s => s)).Dump();
fishes.Count().Dump();