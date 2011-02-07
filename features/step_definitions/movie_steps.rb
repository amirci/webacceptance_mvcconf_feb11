require 'sqlite3'

Given /^I have the following movies:$/ do |table|
  # table is a Cucumber::Ast::Table
  db = SQLite3::Database.new( "C:/temp/movielib.db" )
  db.execute( "delete from Movie" )  
  table.hashes.each do | row |
	db.execute( "insert into Movie ('Title', 'ReleaseDate') values ('#{row['title']}', '1976-08-01')" )  
  end
  db.close
end

Given /^I have no movies$/ do
  db = SQLite3::Database.new( "C:/temp/movielib.db" )
  db.execute( "delete from Movie" )  
  db.close
  sleep(5)
end