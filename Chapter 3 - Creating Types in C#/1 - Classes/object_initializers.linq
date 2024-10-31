<Query Kind="Statements" />



// OBJECT INITIALIZERS
//
// these can be used to set any accessible fields/properties after construction;
// note that you can omit the () on the ctor call in this case for a parameterless
// ctor

var bun_1 = new Bunny { Name = "Bo", LikesCarrots = true, LikesHumans = false };
var bun_2 = new Bunny("Bo") { LikesCarrots = true, LikesHumans = false };

// the compiler will first initialize a temp object using the correct ctor, then set
// the fields/properties on the object, then set your variable to the temp object

// OBJECT INITIALIZERS vs OPTIONAL PARAMETERS
//
// note that we could instead use optional parameters in the ctor instead; generally, this
// would be good as it allows for the fields/properties to be read-only (good practice if
// there is little reason to change them in the future)
//
// there are drawbacks to optional ctor parameters though:
//	- they don't allow for simple nondestructive mutation
//	- they hinder backwards compatibility
// modifying the optional parameters breaks binary compatibility because the optional parameter
// values are substituted at the CALLING SITE (i.e. the compiler translates your call into a call
// with all the parameters defined and the optional params have their default value entered)
//
// any assemblies using the old version will not see the update until they recompile

var bun_3 = new OptBunny(name: "Bo", likesHumans: true);

public class Bunny
{
	public string Name;
	public bool LikesCarrots, LikesHumans;

	public Bunny() { }
	public Bunny(string name) => Name = name;
}

public class OptBunny
{
	
	public readonly string Name;
	public readonly bool LikesCarrots, LikesHumans;

	public OptBunny(string name, bool likesCarrots = false, bool likesHumans = false)
	{
		Name = name;
		LikesCarrots = likesCarrots;
		LikesHumans = likesHumans;
	}
}