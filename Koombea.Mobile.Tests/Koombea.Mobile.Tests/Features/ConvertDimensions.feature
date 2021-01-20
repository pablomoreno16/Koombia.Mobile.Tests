Feature: Convert Units
	As a user
	I want to be able to perform different conversion operations like length, area, volume and speed.

Scenario Outline: Validate Convert values functionality
	Given a user that selects a conversion <operation> from menu
	When the origin unit <unitFrom> is selected
	And the desired unit <unitTo> is selected
	And the <entryValue> is inserted
	Then the result should be <result>
	Examples: 
	| operation | unitFrom           | unitTo                  | entryValue        | result                    |
	| Length    | Kilometer          | Decameter               | -999999999        | -99999999900              |
	| Length    | Kilometer          | Decameter               | 0                 | 0                         |
	| Length    | Kilometer          | Decameter               | 999999999         | 99999999900               |
	| Length    | Fathom             | Fathom                  | -25000            | -25000                    |
	| Length    | [Hist.rus.] Arshin | Kilometer               | 0.0001            | 0.00000007112             |
	| Length    | Kilometer          | [Hist.rus.] Arshin      | 0.00000007112     | 0.0001                    |
	| Area      | Are                | Square thou             | -30               | -4650009300018.6          |
	| Area      | Are                | Square thou             | 0                 | 0                         |
	| Area      | Are                | Square thou             | 30                | 4650009300018.6           |
	| Area      | Are                | Are                     | 30                | 30                        |
	| Area      | Square thou        | Are                     | -4650009300018.6  | -30                       |
	| Volume    | Hectoliter         | Cubic inch              | -999999999999999  | -6102374399999993897.6256 |
	| Volume    | Hectoliter         | Cubic inch              | 0                 | 0                         |
	| Volume    | Hectoliter         | Cubic inch              | 999999999999999   | 6102374399999993897.6256  |
	| Volume    | Hectoliter         | Cubic inch              | 999999999999999   | 6102374399999993897.6256  |
	| Volume    | Hectoliter         | Hectoliter              | 1000              | 1000                      |
	| Speed     | Kilometer per hour | Speed of sound in steel | 0                 | 0                         |
	| Speed     | Kilometer per hour | Speed of sound in steel | 0.0000001         | 0.000000000004661         |
	| Speed     | Seconds per meter  | Speed of sound in steel | 10000000000000000 | 0.00000000000000000002    |
	| Speed     | Kilometer per hour | Kilometer per hour      | 1000              | 1000                      |



Scenario: Only allow positive numbers for Speed operations
	When the operation is Speed
	Then the change sign key is disabled