Feature: MortageCalculatorApp2

Scenario: publish and run Mortage Calculator
Given alteryx running at" http://gallery.alteryx.com/"
And I am logged in using "deepak.manoharan@accionlabs.com" and "P@ssw0rd"
When I publish application: mortgage calculator
And I run mortgage calculator with principle 100000 interest 0.04 payments 36
Then I see output 1200