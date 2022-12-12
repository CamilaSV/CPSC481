# Food App 

### *Introducing Food App, an app made for everyone to streamline planning and communication when you want to eat out.*

#### Background
>*We call ourselves the C4FG*
> Foodies are food enthusiasts who like eating
> out in various restaurants, usually with other people​. However, a
> group of foodies decided that it was difficult to agree on a
> restaurant plan with different preferences and restrictions​.
> Therefore, the group asked us to develop a new social networking app
> that streamlining planning and communication.

###  
## CPSC 481 - Group 12
 ### **Members**
Shanna Hollingworth – shanna.hollingwor1@ucalgary.ca 
Sehwa Kim (Daniel) - sehwa.kim@ucalgary.ca 
Jaydin Lee – jaydin.lee@ucalgary.ca 
Camila Suarez Viltres – camila.suarezviltres@ucalgary.ca 
Bonnie Wu – bonnie.wu@ucalgary.ca 

# Instructions
## Features

Functions/Cases that were implemented into the App:

*You can have two instances of the App running simultaneously.*
 - **Login Page**
	 - The ability to create an account and log into the App
	 - Creating multiple accounts to allow a social network where users can interact with each other
 - **Profile Page**
	 - Users can customize their bio
	 - The user can add friends by entering an email address of an existing user 
	 - The user can also accept or decline a friend request 
	 - Once the user accepts the friend request, the friend can be found under the friend list
	 - Users can remove a friend. *For the user's sake of mind, the user will not be removed from the removed*
 - **Group Chats**
	 - Users can create a new group chat and/or join an existing one
		 - users can invite their friends later or during the creation of the group
	 - Only the group creater can remove users from the group
		 - However, they can give the same removal permission to any group member by promoting them to an 'Admin'
	 - **Messaging system:** 
		 - You can receive and send messages in the chat
		 - The chat can display an upcoming event
		 - The group member can accept or decline an event
			 - If they accept an event, the event is added to their 'Personal Calendar'
	- **Restaurant**
		- The application contains a database of restaurants, and each restaurant includes a list of criteria
		- Users can suggest a restaurant to the group that contains a preset criteria
		- Once a user suggests a restaurant to the group, each group member can vote for a restaurant
		- The any group member can remove a restaurant suggestion 
	- **Custom Criteria**
		- The App contains a database of criteria 
		- Each group member can select a single custom criteria
	- **Scheduler**
		- The scheduler allows the user to have a collection of suggested times
		- A user can suggest a date and time to the group for an upcoming event 
			- By doing so, the suggested time is saved 
		-	The suggested times can be viewed  by clicking on a calendar date
	- **Create an event**
		- With a collection of restaurant and time suggestions from the group, any member could 'plan an event'
		- This is done by selecting a single restaurant and and time. And so the created event gets annouced in the chat
		- Users can attend the event by accepting the event, and this will be saved to their 'Personal Calendar'
		- otherwise they could ignore the interactive notification in the chat or click decline
		-  If the user does not want to be in the event anymore, they could simply remove the event from their personal calendar
- **Personal calendar**
	- This is where all the upcoming and completed events are stored
	- Once the user completes an event, it can be stored or removed
	- to view an upcoming or completed event, the user can simiply select a specific date on the calendar
- **Home Category**
	- The  user can create categorical folders that will be used for saving restaurants 
	- Inside a category, the user can find a restaurant from the database and save it in one of their categories 
	- The user can also make notes for a specific restaurant that they save
- **Under development**
	- User's own dietary options
	- Saving a restauarant from an upcoming or completed event
	- Filtering the user's category by a symbol
	 
## Project File Description
 
 - **CPSC481Group12FoodyApp** - a folder that contains the source files

## System Requirements and Build Process
#### System Requirements :
Visual Studio 2022 version 17.0 or later versions
Make sure the .NET desktop development workload is installed.
The screen resolution needs to be 956 x 1766 or greater
> **Note:** The application may get cropped and this is due to the **display scaling** (*laptop users are more prone to this issue)*.  To solve this issue, please [adjust the display scaling](https://support.microsoft.com/en-us/windows/view-display-settings-in-windows-37f0e05e-98a9-474c-317a-e85422daa8bb) (Recommended scaling: 100%) .


#### Build Process:

 1. Extract the **Zip file**  to your desired directory.
 2. Open **Visual Studio**.
 3. On the start window, select **Open a local folder**
 4.  Locate the **folder**  named **CPSC481Group12FoodyApp** 
		*- This is located in the directory that contains the extracted **Zip file**.*
 5. Prepare the solution in **Solution View** by double-clicking the **CPSC481Group12FoodyApp.sln file.**
 6. **Run** the app by pressing the **Ctrl + F5** keys or by selecting **Debug > Start Without Debugging** from the menu

## Important Information
Upon building and running the **solution** the app creates a local **Database** 

> The upon building and running the solution, the **Database** is created and stored in the **path**: `\CPSC481Group12FoodyApp\CPSC481Group12FoodyApp\bin\Debug\net6.0-windows\DB` The **DB** folder contains 4 `.json` files: `Accounts.json, Criteria.json, Groups.json, Restaurants.json`

Please note that premade accounts are provided for the instructional walkthrough. These accounts contain data generated by the code upon building and running the solution. The login credentials for the auto-generated accounts are shown below:

    Usernames:
	    account1@hotmail.com 
	    account2@hotmail.com 
	    account3@gmail.com 
	    account4@hotmail.com 
	    account5@gmail.com
	    
    Password (for all accounts): 
	    12341234

**Note**: To reset and rebuild the **Database** you need to close the application and delete the **bin folder** .

> Locate the **folder** called **CPSC481Group12FoodyApp** In the path: `\CPSC481Group12FoodyApp\CPSC481Group12FoodyApp\` locate the **bin** folder and **delete** it.  Now **Run** the app *(build process step 4-6)*.

***Note**: Almost nothing is perfect so there may be an occation where the app crashes. Please simply **Run** the app again *(build process step 4-6)* no data will be lost since it uses a database. However, if it doesn't run, please delete the **bin folder** *(Refer to the **Note** above this note)**


## Instructional walkthrough
*Please read all the instructions above before proceeding.*

1. Have two clients opened:

> The app has been designed to run with two clients (two instances of
> the WPF application) for chat simulation. To do this:  Run the app
> twice:
> > 1.  **Run** the app by pressing the **Ctrl + F5** keys or by selecting **Debug > Start Without Debugging** from the menu.
> > 2. Repeat step one.

2. The left client is going to be refered as "**A1**" and the right client is going to be refered as "**A2**"
3. A1: Click "Login" 
4. A1: Enter the email address `account1@hotmail.com`
5. A1: Enter the password `1`
6. A1: Click "Login" (shows error msg)
7. A1: Enter the email address `account1@hotmail.com`
8. A1: Enter the password `12341234`
9. A1: Click "Login"
10. A1: Click the profile icon (top right)
11. A2: We are going to now create a brand new account.
12. A2: Click "Sign Up"
13. A2: Enter the email address: `test1@gmail.com`
14. A2: Enter the password: `123`
15. A2: click the "Register" button
16. A2: Click the profile icon (top right)
17. A2: Click the "Edit" button to edit the bio
18. A2: Click the text field 
19. A2: You can enter any character from your keyboard and then click the check mark to confirm the changes
20. A1: Click the "+" button across from the text "Friend List" 
21. A1: Click into the text field and enter `test1@gmail.com`
22. A1: click the "add" button
23. A1: click the "back" button
24. A2: You can see that a Friend Request has appeared. 
25. A2: Click the "green checkmark" to add `account1@hotmail.com` as a friend
26. A1: Click the "back" button which is located at the top left of the screen
27. A1: Click the "red x" on account 5 
28. A1: Under Friend List, click the "trash" bin icon for the user `test1@gmail.com`
29. A2: Under Friend List, click the "trash" bin icon for the user `account1@hotmail.com`
30. A2: Click the "+" button accross from the text "Friend List"
31. A2: Enter `account1@hotmail.com` in the field
32. A2: Click the "add" button
33. A1: scroll down the Friend Request List
34. A1: Click the "red X" button to decline the friend request
35. A1: In the Friend Request List, Click the "green checkmark" for both `account4@hotmail.com` and `account5@gmail.com`
36. A2: Close the application (Top right corner "x")
37. A2: Run a new insstance (open new client)
>  Reminder on how to run: **Run** the app by pressing the **Ctrl + F5** keys or by selecting **Debug > Start Without Debugging** from the menu.
38. A2: click the "Login" button
39. A2: Enter the email address: `account2@hotmail.com`
40. A2: Enter the password: `12341234`
41. A1: Click the "chat bubble" from the navigation bar below
42. A1: Click the "Plus" button 
43. A1: Enter `group` in the text field
44. A1: Check the "check box" for `account2@hotmail.com`
45. A1 Click the "create group" button
46. A1: Click the group called "group" 
47. A2: Click the "chat request" button on the top left of the screen
48. A2: Click the "check mark" button for "group"
49. A2: Click the "back" button
50. A2: Click on the group called "group"
51. A2: Click the text field that says "enter your chat message here:"
52. A2: Type `hello`
53. A2: Click the "airplane" icon to send the message
54. A1: Type `Welcome` in the text field that says "enter your chat message here:"
55. A1: Click the "airplane" icon to send the message (demonstration of live chat and group creation)
56. A1: Click the "back" button located on the top left of the screen
57. A1: Click on the group called "FOODIES"
58. A1: Click on the top right "information" button
59. A1: Under invite members, check all three check boxes
60. A1: Click the "confirm" button
61. A2: Close the app. (top right x)
62. A2: Run a new insstance (open new client)
>  Reminder on how to run: **Run** the app by pressing the **Ctrl + F5** keys or by selecting **Debug > Start Without Debugging** from the menu.
63. Click the "login" button
64. Enter `account3@gmail.com` in the email field
65. Enter `12341234` in the password field
66. Click the "chat request button" top left
67. Click the "check button" for "FOODIES"
68. Click the "x" button for "Enjoy"
69. A2: Click the "back" button located on the top left of the screen
70. A2: Click on the group called "FOODIES"
71. A2: Click the "back" button
72. A1: Click the "trash bin" button for "account3@gmail.com"
73. A1: Click "yes"
74. A1: Under Invite Members check the box for `account3@gmail.com`
75. A1: click the "confirm" button
76. A2: click the "chat request" button 
77. A2: click the "check mark" Button for foodies
78. A2: click the group called "FOODIES"
79. A1: Click the "back" button twice
80. A2: Enter `hi` in the text field
81. A2: click the "airplane" button to send the message
82. A2: Click the "yes" Button for the "attend event" card
83. A2: click the "back" button
86. A2: Click the "calendar" button
87. A2: Click the "save restaurant" button
88. A2: Click the "ok" button
89. A2: Click the "delete event' button
90. A2: click the "ok" button
91. A2: Click the "chat bubble Icon" Button
92. A2: Click the group called "FOODIES"
93. A2: Click the "information" icon on the top right
94. A2: click the "click here to see times..." button
95. A2: Click the date that is highlighted gray on the calendar (today's actual date)
96. A2: Suggested time is shown
97. A2: Click the "Click to add custom time..."
98. A2: Click the "date" icon"
99. A2: Select: `December 27, 2022`
100. A2:  Click on the Time text field and type: `10:19`
101. A2: click the "AM" button
102. A2: Click the 'submit' button
103. A2: Click the "click here to see times..." button
104. A2: Click the date ` December 27, 2022` should see your time got added to the suggested time)
105. A2: Click the back button
106. A2: Click "edit" criteria
107. A2: click the drop down menu and select "Meat" 
108. A2: Click the "select" button
109. A2: Click the "back" button
110. A2: Click "edit restaurant" button
111. A1: Click the 'information' Button
112.  A1: Click "edit restaurant" button
113. A1: Click the + button
114. A1: Select a restaurant until the "criteria" contains 4 or more criteria (restaurant data base randomly generated once bin folder gets built)
115. A1: Click the "submit restaurant" button
116. A1: click the "back" button
117. A1: Scroll down the list to the very bottom
118. A1: click the show more text on the last card
119. A1: click the click to minimize
120. A1: Click the vote button for the last card
121. A2: scroll down to the list
122. A2: click the vote button on the last card
123. A1: click the back button 
124. A2: click the back button twice
125. A1: Click "click to add custom time..."
126. A1: Click the calendar icon and then select the gray date (actual date)
127. A1: **IMPORTANT**: Look at your computer's time, (convert it to 12 hr format and enter it in HH:MM format) add 4 minutes to the current time and then input that time in the text field. `e.g. Computer time says: 02:02 PM or 14:02, enter 02:06 in the text field and then select the AM button` 
128. A1: Click submit
129. A1: click the back button
130. A1: Click "click to create event"
131. A1: Click the "Click to create event" button
132. A1: select "Taiyo" as the restaurant
133. A1: Select the "Custom time created in step 127."
134. A1: Click "create event!" button
135. A1: Click the "back" button 2 times
136. A1: Click the personal calendar "button"
137. A2: Click the "decline" button for the Event card
140. A2: Click the group called "FOODIES"
141. A2: click the "back" button
142. A1: **NOTE WAIT UNTIL THE EVENT BEGINS UNDER UPCOMING EVENT**
143. A1: after 4 minutes of creating the event, the taiyo event card should be moved to the completed events.
144. A2: click the "personal calendar " button (since event declined doesn't show up)
145. A1: Click the "chat bubble" icon 
146. A1: Click the group chat called "FOODIES"
147. A1: Click the "information" icon
148. A1: Click "click to create event"
149. A1: Select Calgary Court Restaurant 
150. A1: Find and Select `"December, 27, 2022 @ 10:19` as the time
151. A1: Create event
152. A2: Click the chat bubble 
153. A2: click the "yes: button" for the attent event card for Calgary court 
154. A2: "Click the back button"
155. A2: "Click the "personal calendar" button
156. A2: on the calendar select `December 22, 2022" It should display calgary court as upcoming event
157. A1: Click the back button 3 times
158. A1: click the "home" button icon
159. A1: click the Plus button
160. A1: Enter `my folder` in the text field
161. A1: click the Add button
162. A1: click the purple square called `my folder`
163. A1: click the plus button
164. A1: select "taiyo" as the restaurant
165. A1: click add restaurant
166. A1: click the back button
167. A1: click the "star" 
168. A1: click the "ok" button 
169. A1: CLick the show more button
170. A1: click the "edit " button
171. A1: type `yummy`
172. A1: click the "check mark" button
173. A1: Click the back button
174. A1: Click the "show more" button
175. A1: click the trash bin

Done. Close all apps.
