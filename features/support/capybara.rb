require 'capybara/cucumber'
require 'selenium-webdriver'
	
Capybara.default_driver = :selenium
Capybara.app_host = "http://localhost:1591" 	
Capybara.run_server = false

# Capybara defaults to XPath selectors rather than Webrat's default of CSS3. In
# order to ease the transition to Capybara we set the default here. If you'd
# prefer to use XPath just remove this line and adjust any selectors in your
# steps to use the XPath syntax.
Capybara.default_selector = :css

#Capybara.register_driver :selenium do |app|
#  Capybara::Driver::Selenium.new(app, :browser => :ie)
#end