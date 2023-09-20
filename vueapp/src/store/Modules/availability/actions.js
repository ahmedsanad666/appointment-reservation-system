const BaseLink = "https://localhost:7063/api/UserAvailability";

export default {
  async UserAvailability(context, userid) {
    const response = await fetch(`${BaseLink}/${userid}`);
    const responseData = await response.json();

    if (!response.ok) {
    
      const error = new Error(responseData.message || "failed to get category");

      throw error;
    }

    context.commit("setavailableTimes", responseData);
  },

  async setAvailableTimes(_, paylaod) {
    const response = await fetch(BaseLink, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });

    console.log(response, JSON.stringify(paylaod));
    if (!response.ok) {
      console.log(response);
      const error = "failed to send data";
      throw error;
    }
  },

  async updateAvailableTimes(_, paylaod) {
    const response = await fetch(`${BaseLink}/${paylaod.id}`, {
      method: "PUT",

      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paylaod),
    });
    console.log(response);

    if (!response.ok) {
      console.log(response);
      const error = "failed to send data";
      throw error;
    }
  },
};
