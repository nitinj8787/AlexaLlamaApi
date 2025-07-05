# AlexaLlamaApi

The Alexa Llama API is an ASP.NET Core Web API that enables conversational interactions between Amazon Alexa and a Llama-based language model. It acts as a middleware service, processing Alexa skill requests, maintaining chat session memory, and forwarding user questions to a Llama model for intelligent responses.

Key Features:

•	Alexa Skill Integration: Receives and processes Alexa skill requests (Launch, Intent, Session End).

•	Llama Model Communication: Forwards user questions to a Llama language model and returns generated answers.

•	Session Memory: Maintains chat history per session for context-aware conversations.

•	RESTful Endpoint: Exposes a /api/Chat/process POST endpoint for Alexa requests.

•	Extensible: Easily adaptable for other conversational AI models or platforms.



Typical Usage:

1.	Alexa sends a request (e.g., user asks a question).
2.	The API processes the request, manages session memory, and sends the question to the Llama model.
3.	The Llama model’s response is returned to Alexa in a format suitable for voice output.


Getting Started:

•	Configure the Llama model endpoint in appsettings.json under LlamaApi:Url.

•	Build and run the API.

•	Use the /swagger endpoint for API documentation and testing.

