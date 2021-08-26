function startLoader() {
    const preloader = document.querySelector(".preloader");

    window.addEventListener("DOMContentLoaded", function() {
      setTimeout(function() {
        preloader.style.visibility = "hidden";
        document.body.classList.remove("loading");
      }, 4000);
    });
  }
  
  startLoader();
  