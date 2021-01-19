Feature: Convert Units
	As a user
	I want to be able to perform different conversion operations like length, area, volume and speed.

Scenario Outline: Title change once an operation is selected.
	When the menu button is tapped
	Then the <operation> is selected and displayed in the title
	Examples:
	| operation |
	| Length    |
	| Area      |
	| Volume    |
	| Speed     |

Scenario Outline: Validate that the user is able to convert values
	Given a user that selects a conversion <operation> from menu
	When the original unit <unitFrom> is selecteded
	And the desired unit <unitTo> is selected
	And the <entryValue> is inserted
	Then the result should be <result>
	Examples: 
	| operation | unitFrom  | unitTo     | entryValue | resultLength |
	| Length    | Decimeter | Centimeter | 5000       | 50000        |