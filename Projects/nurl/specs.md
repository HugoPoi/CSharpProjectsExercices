1. Feature:  GET

* In order : to see the content of a web page
* as a : shell fan
* I want to download a web page

Scenario: show the content of a page
* Given : I entered a fake url option `-url "http://fake"`
* And : any other option
* When : I press enter
* Then : the result should be `<h1>hello</h1>`

Scenario: save the content of a page
* Given : I entered a fake url option `-url "http://fake"`
* And : I enter the option `-save` with the value 'fake.txt'
* When : I press enter
* Then : a file called `fake.txt` should be created with the content `<h1>hello</h1>`
