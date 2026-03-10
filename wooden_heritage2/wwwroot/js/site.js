document.addEventListener("DOMContentLoaded", function () {
	const main = document.querySelector("main");
	if (main) {
		main.classList.add("fade-in");
	}

	const form = document.getElementById("contactForm");
	if (form) {
		form.addEventListener("submit", function (e) {
			e.preventDefault();

			const name = document.getElementById("name").value.trim();
			const email = document.getElementById("email").value.trim();
			const message = document.getElementById("message").value.trim();

			if (!name || !email || !message) {
				alert("Please fill out all fields.");
				return;
			}

			const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
			if (!emailPattern.test(email)) {
				alert("Please enter a valid email address.");
				return;
			}

			alert("Thank you, " + name + "! Your message has been sent.");
			form.reset();
		});
	}
});