<h1>Piano Tiles - Prototype (Unity)</h1>
<p>This is a prototype of the game "Piano Tiles". All scrips have been commented to make things clearer.</p>
<h2>How it works:</h2>
<p>Simply there are 4 scripts</p>
<ul>
	<li>
		<h3>GameManager</h3>
		<p>It's responsible for almost everything in the game.</p>
	</li>
	<li>
		<h3>Note</h3>
		<p>Each note prefab has a <i>Note</i> script that gives it what note to play once it's clicked. Also, it has a status to show whether it's active or not.</p>
	</li>
	<li>
		<h3>MusicNotes</h3>
		<p>This is a <i>Scriptable Object</i> which holds the notes for each music.</p>
		<p>To create a new <i>MusicNotes</i> go to</p>
		<p>```Right click > Create > MusicNotes```</p>
		<p>From here, you can assign the notes in the <i>notes</i> array following this format:</p>
		<p>```NOTE:ORDER```</p>
		<p>Example of placing the note <i>B</i> on the third column:</p>
		<p>```B:3```</p>
		<p>Then you assign that <i>MusicNotes</i> instance to the <i>musicNotes</i> in the <i>GameManager</i> script.</p>
	</li>
	<li>
		<h3>BackgroundHit</h3>
		<p>Simply whenever the background is clicked it will play an off-tune sound then it will end the game.</p>
	</li>
</ul>