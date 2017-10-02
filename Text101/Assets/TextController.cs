using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {


	/* Info on enum
	credit is instruction and thanks.
	inititate is GameStart().
	cell_0 is first cell, player starts in.
	mirror_0 is first mirror, finds key.
	mirror_1 is second mirror, scratch it.
	lock_0 is first lock to find out that door's locked
	lock_1 is use key to unlock lock_0.
	sheets_0 is first sheets, smelly.
	sheets_1 is second sheets, nothing happens.
	key_0 is first key, choose what to do with it.
	freedom_0 is first freedom after escape from cell_0.
	corridor_0 is first corridor after exiting room.
	corridor_1 is second corridor.
	savepoint_0 is first save return point at level 2.
	stairs_0 is first trap stairs on level 2.
	stairs_1 is second trap stairs.
	cell_1 is second cell with monster.
	lock_2 is second locked cell_1.
	lock_3 is use key to unlock lock_2.
	guard_0 is first guard whom attacks.
	guard_1 is sleeping guard_0.
	monster_0 is first monster locked in cell_1.
	monster_1 is monster_0 out of cell_1.
	listen_0 is listening to monster_0.
	freedom_1 is second freedom after escape with monster.

	*/

	#region Declarations

	//Declaration of vars
	public Text textObject;
	private States myStates;
	private bool checkedDoor = false;  //for mirror_0() to have 2 different response. 
	private bool listenedMonster = false; //for monster_1 event-tree to trigger.
	private enum States 	{	credit, initiate, //Divide lines per level (0)
								cell_0, mirror_0, mirror_1, lock_0, lock_1, sheets_0, sheets_1, key_0, freedom_0, //Divide lines per level (1)
							 	corridor_0, corridor_1, savepoint_0, stairs_0, stairs_1, cell_1, lock_2, lock_3, 
							 	guard_0, guard_1, monster_0, monster_1, listen_0, freedom_1		 //Divide lines per level (2)
						 	};
	/*For learning about enum
	private enum Days
	{
		Sat,
		Sun,
		Mon,
		Tues,
		Wed,
		Thurs,
		Fri

	};
	private Days myWeekend;*/

	#endregion

	#region void Start() and Update()

	// Use this for initialization
	void Start () {
		myStates = States.credit;

		/*For testing on enums, class of enum and the constants inside of enum
		int x = (int)Days.Fri;
		print (x); //with Sat=0 as default
		print (myWeekend); //result is Sat */

	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myStates);
		if (myStates == States.credit)				credit ();
		else if (myStates == States.initiate)		initiate ();
		else if (myStates == States.cell_0)			cell_0 ();
		else if (myStates == States.mirror_0) 		mirror_0 ();
		else if (myStates == States.mirror_1)		mirror_1 ();
		else if (myStates == States.lock_0)			lock_0 ();
		else if (myStates == States.lock_1) 		lock_1 ();
		else if (myStates == States.sheets_0) 		sheets_0 ();
		else if (myStates == States.sheets_1 ) 		sheets_1 ();
		else if (myStates == States.key_0) 			key_0 ();
		else if (myStates == States.freedom_0) 		freedom_0 ();
		else if (myStates == States.corridor_0) 	corridor_0 ();
		else if (myStates == States.corridor_1) 	corridor_1 ();
		else if (myStates == States.savepoint_0) 	savepoint_0 ();
		else if (myStates == States.stairs_0) 		stairs_0 ();
		else if (myStates == States.stairs_1) 		stairs_1 ();
		else if (myStates == States.cell_1) 		cell_1 ();
		else if (myStates == States.lock_2) 		lock_2 ();
		else if (myStates == States.lock_3) 		lock_3 ();
		else if (myStates == States.guard_0) 		guard_0 ();
		else if (myStates == States.guard_1) 		guard_1 ();
		else if (myStates == States.monster_0) 		monster_0 ();
		else if (myStates == States.monster_1) 		monster_1 ();
		else if (myStates == States.listen_0) 		listen_0 ();
		else if (myStates == States.freedom_1) 		freedom_1 ();

	}

	#endregion

	#region State methods for level 0 & 1
	//In credit
	void credit (){
		textObject.text = "Made by NanoBit with Unity. Thanks to Ben. \n \t\t\t\t >>>>>Press Space to Start or Restart!<<<<<";
		this.checkedDoor = false;
		this.listenedMonster = false;
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStates = States.initiate;
		} //to tell instructions and credit
	}

	//In inititate
	void initiate (){
		textObject.text = 	"[Wake up... wAKE Up!] \n"
						+	"(Slowly opening your eyes as you heard the call, you see darkness around you, and a few items.) \n"
						+	"[Finally! You're awake!] \n"
						+	"[Welcome to my World, Pappppi.] \n"
						+	"[You are my ~first visitor. Have Fun!] \n"
						+	"[>>There is no greater joy for me than you being here<<] \n"
						+	"\t\t\t\t Press L to Look around! \n";

		if (Input.GetKeyDown (KeyCode.L)) myStates = States.cell_0;
	}

	// In cell
	void cell_0 ()
	{
		//To make sure they see the door locked from inside. Also to test with bool var types.
		if (checkedDoor) {
			textObject.text = 	"(You look around, while feeling hungry) \n"
							+	"There's bed sheets, a mirror, and a locked door in this room. \n"
							+	"\t\t\t\t Press S to search around the bed Sheets! \n"
							+	"\t\t\t\t Press M to search around the Mirror! \n"
							+	"\t\t\t\t Press L to search around the Locked door! \n";
		} else {
			textObject.text = 	"(You look around, while feeling hungry) \n"
							+	"There's bed sheets, a mirror, and a locked door in this room. \n"
							+	"\t\t\t\t Press S to search around the bed Sheets! \n"
							+	"\t\t\t\t Press L to search around the Locked door! \n";
		}
		if (Input.GetKeyDown (KeyCode.S)) myStates = States.sheets_0;
		if (Input.GetKeyDown (KeyCode.M)) myStates = States.mirror_0;
		if (Input.GetKeyDown (KeyCode.L)) myStates = States.lock_0;
	}

	//In mirror_0
	void mirror_0 () {
		textObject.text = 	"Oh! What's this?! A Key! \n"
						+	"Maybe it could be of some use.. \n"
						+	"\t\t\t\t Press K to retrieve the Key! \n"
						+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.K)) myStates = States.key_0;
		if (Input.GetKeyDown (KeyCode.R)) myStates = States.cell_0;
	}

	//In mirror_1
	void mirror_1 () {
		textObject.text = 	"(Holding the key, proceed to scratching the mirror) *SCREEEEEEECH* \n"
						+	"Besides this painful tune, nothing happened. \n"
						+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.key_0;
	}

	//In lock_0
	void lock_0 ()
	{
		textObject.text = 	"The door is locked! \n"
						+	"But from the inside? Strange... Maybe I'll look around a bit more. \n"
						+	"\t\t\t\t Press R to return back! \n";

		if (Input.GetKeyDown (KeyCode.R)) {
			myStates = States.cell_0;
			checkedDoor = true;
		}
	}

	//In lock_1
	void lock_1 () {
		textObject.text = 	"(Puts key into lock and slowly but eventually turning it) *Click* \n"
						+	"Ohh? It worked?! HEavVENs is HELPing Me! HUUURRRAYYY. \n"
						+	"\t\t\t\t Press R to Run out! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.freedom_0;
	}

	//In sheets_0
	void sheets_0 () {
		textObject.text = 	"Nothing's behind here! \n"
						+	"But Whew! It smells bad. \n"
						+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.cell_0;
	}

	//In sheets_1
	void sheets_1 () {
		textObject.text = 	"(Poking bed sheets with a key) \n"
						+	"Nothing magical happened. :( \n"
						+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.key_0;
	}

	//In key
	void key_0 () {
		textObject.text = 	"Hmm a key in hand. Sheets to the left, a mirror in front, a lock to the right. \n"
						+	"I think I can do something with this. \n"
						+	"\t\t\t\t Press S to poke the Sheets with it! \n"
						+	"\t\t\t\t Press M to try scratch the Mirror with it! \n"
						+	"\t\t\t\t Press L to try unLock the door! \n"
						+	"\t\t\t\t Press R to Return the key! \n";

		if (Input.GetKeyDown (KeyCode.S)) myStates = States.sheets_1;
		if (Input.GetKeyDown (KeyCode.M)) myStates = States.mirror_1;
		if (Input.GetKeyDown (KeyCode.L)) myStates = States.lock_1;
		if (Input.GetKeyDown (KeyCode.R)) myStates = States.cell_0;
	}

	//In freedom
	void freedom_0 () {
		textObject.text = 	"(A light from outside blinded you) \n"
						+	"(You feel your consiousness sucked away ..a g ain...again??!!!) \n"
						+	"\t\t\t\t Press C to Continue on! \n";

		if (Input.GetKeyDown (KeyCode.C)) myStates = States.corridor_0;
	}

	#endregion

	#region State methods for level 2
	//In corridor_0 
	void corridor_0 () {
		textObject.text = 	//"(You slowly awake, trying to remember what happened. Frowning) That..that feeling of familiarity.... \n"
							"(Observing your surroundings, you realize) I'm in a--a corridor?  \n"
						+	"A black-haired guard is seen around the bend. Another cell is seen nearby, whereas to the front is a suspicious pathway going down.\n"
						+	"\t\t\t\t Press G to go talk to the Guard! \n"
						+	"\t\t\t\t Press S to check the Stairs! \n"
						+	"\t\t\t\t Press C to look into the Cell! \n";

		if (Input.GetKeyDown (KeyCode.C)) myStates = States.cell_1;
		if (Input.GetKeyDown (KeyCode.G)) myStates = States.guard_0;
		if (Input.GetKeyDown (KeyCode.S)) myStates = States.stairs_0;
	}

	//In corridor_1
	void corridor_1 ()
	{
		textObject.text = "Hmm there's a path ahead, quite dark though.. Or should I go back? \n"
		+	"\t\t\t\t Press C to Continue ahead! \n"
		+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.C))	myStates = States.stairs_1;
		if (Input.GetKeyDown (KeyCode.R)) {
			if (listenedMonster)
				myStates = States.lock_3;
			else
				myStates = States.lock_2;
		}

	}


	//In savepoint_0
	void savepoint_0 () {
		textObject.text = 	"(A sharp pain suddenly sparked in your mind. Memories from unknown sources resounded in your mind.) \n"
						+	" ....Did that happen..? Maybe .. it did-----or not ----- \n"
						+	"(As you try to recollect, you look around.) \n"
						+	"\t\t\t\t Press C to Continue looking around! \n";

		if (Input.GetKeyDown (KeyCode.C)) myStates = States.corridor_0;
	}

	//In stairs_0
	void stairs_0 () {
		textObject.text = 	"(As you walk, you suddenly feel a sudden coldness. As you look towards your left arm. ) \n"
						+	" AHHH!!!!! \n"
						+	"(You tried hard to stop the bleeding but you were too late.....) \n"
						+	"\t\t\t\t Press R Regain consciousness! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.savepoint_0;
	}

	//In stairs_1
	void stairs_1 () {
		textObject.text = 	"*BANG* *CRASH* *TOOT*  \n"
						+	" <Censored>!!!!!!!!!!!!!!!!!!!!!!!!!!! \n"
						+	"(You tripped and fell into a large hole while approaching the end of the corridor. It's definite you broke your legs.) \n"
						+	"(You collapsed due to starvation and the raging pain!) \n"
						+	"\t\t\t\t Press R Regain consciousness! \n";

		if (Input.GetKeyDown (KeyCode.R)) myStates = States.savepoint_0;
	}

	//In cell_1
	void cell_1 () {
		textObject.text = 	"There's a mm-mmOnster inside the locked cell.  \n"
						+	"(You slowly back away) There's 232 imprinted to the left of the cell. \n"
						+	"\t\t\t\t Press M to approach the Monster! \n"
						+	"\t\t\t\t Press L to check the Lock! \n"
						+	"\t\t\t\t Press R to Retreat! \n";

		if (Input.GetKeyDown (KeyCode.M))	myStates = States.monster_0;
		if (Input.GetKeyDown (KeyCode.L))	myStates = States.lock_2;
		if (Input.GetKeyDown (KeyCode.R))	myStates = States.corridor_0;
	}

	//In lock_2
	void lock_2 () {
		textObject.text = 	"It's fastened tight! However in contrast to mine, it's locked from the outside... Why was mine from the inside---  \n"
						+	"Oh?! There's another guard, white-haired at the far end. Maybe he has a key.. \n"
						+	"Wait, what am I thinking? Trying to let the monster out?!!  \n"
						+	"\t\t\t\t Press C to continue checking out the Corridor! \n"
						+	"\t\t\t\t Press G to approach the Guard! \n"
						+	"\t\t\t\t Press R to Return to the monster's cell again! \n";

		if (Input.GetKeyDown (KeyCode.G))	myStates = States.guard_1;
		if (Input.GetKeyDown (KeyCode.C))	myStates = States.corridor_1;
		if (Input.GetKeyDown (KeyCode.R))	myStates = States.cell_1;
	}

	//In lock_3
	void lock_3 () {
		textObject.text = 	"I got the key now. THe real question now is to Save It or Forget about It? Do I believe It? Can I trust It? \n"
						+	"What if-- he kills me? :O \n"
						+	"What if-- I become his meal?  \n"
						+	"What if-- .... \n"
						+	"\t\t\t\t Press M to unlock the lock for the Monster! \n"
						+	"\t\t\t\t Press C to continue checking out the Corridor! \n";

		if (Input.GetKeyDown (KeyCode.M))	myStates = States.monster_1;
		if (Input.GetKeyDown (KeyCode.C))	myStates = States.corridor_1;
	}

	//In guard_0
	void guard_0 () {
		textObject.text = 	"(Guard shouts in an unknown language.) '&@^#%@&!!'  \n"
						+	"(Guard unsheathes his sword.          And Slashed! \n"
						+	"(@You feel the world spinning@)  \n"
						+	"\t\t\t\t Press R Regain consciousness! \n";

		if (Input.GetKeyDown (KeyCode.R))	myStates = States.savepoint_0;
	}

	//In guard_1
	void guard_1 ()
	{
		if (listenedMonster) {
			textObject.text =	"(Guard snoring) \n"
							+	"What did that monster do? I thought he was awake just now?? \n"
							+	"That rack of keys... Wait how do I kno- 100,230,550,420,232   \n"
							+	"I think the cell was numbered 232. \n"
							+	"\t\t\t\t Press L to get the key for the Lock! \n";

			if (Input.GetKeyDown (KeyCode.L))
				myStates = States.lock_3;
		} else { 
			textObject.text =	"(Guard looking left and right constantly) \n"
							+	"I don't think he's going to help. \n"
							+	"(As you try to go back, you made a slight but audible sound)   \n"
							+	"(The guard turns and face your way \t You run \t But he catches up, and you suddenly fainted.) \n"
							+	"\t\t\t\t Press R to Regain consciousness! \n";
			if (Input.GetKeyDown (KeyCode.R))
				myStates = States.savepoint_0;
		}
	}

	//In monster_0
	void monster_0 () {
		textObject.text = 	"(As you walk closer, the monster feels your presense. It opens its eyes)   \n"
						+	"It looks like it's trying to say something, or it could be him trying to bait you closer.. \n"
						+	"\t\t\t\t Press L to get closer to Listen to it!  \n"
						+	"\t\t\t\t Press R to Return back! \n";

		if (Input.GetKeyDown (KeyCode.L))	myStates = States.listen_0;
		if (Input.GetKeyDown (KeyCode.R))	myStates = States.cell_1;
	}

	//In monster_1
	void monster_1 () {
		textObject.text = 	"('Thank you for saving This King, Human. As promised, This King here will fullfill your wish!', resounded in your mind.)   \n"
						+	"YES!! Finally I can leave this creepy place! \n"
						+	"(The monster, wtih a glimmer in its eyes, suddenly approached. It opened its mouth...) *CHOMP* \n"
						+	"\t\t\t\t Press C to Continue on! \n";

		if (Input.GetKeyDown (KeyCode.C))	myStates = States.freedom_1;
	}

	//In listen_0
	void listen_0 ()
	{
		textObject.text = "(The monster constantly panting..) 'Get the key for This King', resounded in your mind.   \n"
		+	"What?! Did it just talk ? Did it? Oh my! But it didn't open its mouth. Unless.. \n"
		+	"IT SPOKE TELEPATHICALLY!!?? \n"
		+	"(As if you were in a trance, you walked toward the white-haired guard) \n"
		+	"\t\t\t\t Press G to approach towards the Guard! \n";

		
		if (Input.GetKeyDown (KeyCode.G)) {
			myStates = States.guard_1;
			listenedMonster = true;
		}
	}

	//In freedom_1
	void freedom_1 () {
		textObject.text = 	"(Memories constantly swirling around in your mind)   \n"
						+	"(Bright lights flashing on and off in a timely fashion) \n"
						+	"'Are you ok, son?', a stranger spoke. \n\n"
						+	"\t\t\t\t <<<<Hurray for Completing Story Part I>>>> \n";

	}
	#endregion

}
