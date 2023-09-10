const BaseLink = "https://localhost:7063/api/appointment";
const BookEvent = "https://localhost:7063/api/BookedEvent";

export default {
  //...................... category
  async eventToBooked(context) {
    const response = await fetch(BaseLink);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(responseData.message || "failed to get category");

      throw error;
    }
    const all = [];
    responseData.forEach((element) => {
      all.push(element);
    });
console.log(all)
    context.commit("setEventsToBooked", all);
  },

  async UserEvents(context, userid) {
    const response = await fetch(`${BaseLink}/${userid}`);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(responseData.message || "failed to get category");

      throw error;
    }
    const UserEvents = [];
    responseData.forEach((element) => {
      UserEvents.push(element);
    });

    context.commit("setEvents", UserEvents);
  },
  async addApp(_, paylaod) {
    const response = await fetch(BaseLink, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },
  //...................... book

  async BookEvent(context) {
    const response = await fetch(BookEvent);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(responseData.message || "failed to get books");

      throw error;
    }
    const BookedEvents = [];
    responseData.forEach((element) => {
      BookedEvents.push(element);
    });

    context.commit("setBookedEvents", BookedEvents);
  },
  async AddBookedEvent(_, paylaod) {
    const response = await fetch(BookEvent, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });
    console.log(JSON.stringify(paylaod));
    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },

  // .................................. questions
  async getBookQuestions(context) {
    const response = await fetch(QuestionsLink);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(responseData.message || "failed to get quesiots");

      throw error;
    }
    const questions = [];
    responseData.forEach((element) => {
      questions.push(element);
    });

    context.commit("setquestions", questions);
  },

  async AddQuestion(_, paylaod) {
    const response = await fetch(QuestionsLink, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },
  // .................................. grants

  async GetLibraries(context) {
    const response = await fetch(libraryLink);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(
        responseData.message || "failed to get libraries "
      );

      throw error;
    }
    const libraries = [];
    responseData.forEach((element) => {
      libraries.push(element);
    });

    context.commit("setlibraries", libraries);
  },

  async AddLibrary(_, paylaod) {
    const response = await fetch(libraryLink, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },
  // .................................. grants

  async GetGrants(context) {
    const response = await fetch(GrantsLink);
    const responseData = await response.json();

    if (!response.ok) {
      const error = new Error(responseData.message || "failed to get grants");

      throw error;
    }
    const grants = [];
    responseData.forEach((element) => {
      grants.push(element);
    });

    context.commit("setGrants", grants);
  },

  async AddGrant(_, paylaod) {
    const response = await fetch(GrantsLink, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },
  //..... update quesiotn
  async AddQuestionData(_, paylaod) {
    const response = await fetch(questionData, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    if (!response.ok) {
      const error = "failed to send data";
      throw error;
    }
  },
};
