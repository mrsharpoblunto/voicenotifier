Voice Notifier
==============

An application which allows you to remotely send speech to a host computer running this program.

When the program is running you can send a speech request by entering the following url into a web browser

http://(host ip address):8080?text=your text here

The speech sent will then be played through the host computers speakers

Note: If running windows Vista you will have to go to the installation directory and open notifierWindowsService.exe.config and change the SynthVoice from "Microsoft Sam" to "Microsoft Anna"