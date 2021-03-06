## Usage:

Main logic is in Processor class, initialize it and use these methods:
- **AddMessage, AddMessages** for add messages into queue
- **ProceedQueue** to execute queue

## Before begin:

Change configuration paths located at **MessageProcessorTests\App.config**


## Requiremens:
You are the new server side developer at this new shiny start-up, Acme Email. The product the company is feverishly trying to push out is a Message Processor (c). The front end is being developed by the expert Acme front end team. The product is an Enterprise grade application.
The Message Processor (c) processes different type of messages. At the moment Acme supports two types of messages:
- Birthday Wish
- Congrats on the birth of your child

This is only the start. Over time Acme plans to add other types of Messages like "Anniversary, Job Promotion, Happy 21st, etc." They want to corner the Message Processor market.
What you need to do is process a process a queue of in coming messages. There is one queue for all messages.

**Birthday Message Process:**
- Convert 'Standard Message Text' field to all Upper case.
- Serialize to json and write to file in directory /Birthdays

**Congrats on the birth of your child Process:**
- Base 64 encode the 'Name' field
- Format 'BabyBirthday' field to 'dd MMM yyyy' - like "23 Jan 2013"
- Serialize to xml and write to file in directory /BabyBirth

In each case you need to write to a log file the MessageId, MessageType and full file path where to find the processed message. The log needs to live in /Log directory.

**The common fields for all messages are:**
- MessageId - Unique Id
- MessageType - Type of message
- Name - Who the message is to.
- Standard Message Text - Message Text, like 'Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: PS3. Enjoy.'

**For Birthday Messages you also have:**
- BirthDate
- Gift

**For Congrats on the birth of your child:**
- Gender
- BabyBirthDay
