// Profile Page 
const menuItems = document.querySelectorAll('.menu-item');
    const editSection = document.getElementsByClassName("edit-profile-section")[0];
    const bookingSection = document.getElementsByClassName("mybooking-section")[0];
    const reviewSection = document.getElementsByClassName("review-section")[0];

    menuItems.forEach(item => {
        item.addEventListener('click', () => {
            menuItems.forEach(i => i.classList.remove('active'));
            item.classList.add('active');

            if (item.classList.contains('edit-side')) {
                editSection.style.display = 'block';
                bookingSection.style.display = 'none';
                reviewSection.style.display = 'none';
                addBookingBtn.style.display = 'none';
            } else if (item.classList.contains('my-reviews')) {
                reviewSection.style.display = 'block';
                editSection.style.display = 'none';
                bookingSection.style.display = 'none';
                addBookingBtn.style.display = 'none';
            } else {
                bookingSection.style.display = 'block';
                editSection.style.display = 'none';
                reviewSection.style.display = 'none';
                addBookingBtn.style.display = 'block';
            }
        });
});


// Booking Page
const steps = document.querySelectorAll('.form-step');
  const indicators = document.querySelectorAll('.step');
  let currentStep = 0;

  let bookingData = {
    date: '',
    time: '',
    duration: '',
    payment: ''
  };

  function showStep(index) {
    steps.forEach(step => step.classList.remove('active'));
    indicators.forEach(ind => ind.classList.remove('active'));
    steps[index].classList.add('active');
    indicators[index].classList.add('active');
    currentStep = index;
  }

  document.getElementById("next-date-time").addEventListener("click", () => {
    bookingData.date = document.getElementById("date").value;
    bookingData.time = document.getElementById("time").value;
    showStep(1);
  });

  document.getElementById("next-duration").addEventListener("click", () => {
    const selectedDuration = document.querySelector('input[name="duration"]:checked');
    if (selectedDuration) {
      bookingData.duration = selectedDuration.value;
    }
    showStep(2);
  });

  document.getElementById("next-payment").addEventListener("click", () => {
    const selectedPayment = document.querySelector('input[name="payment"]:checked');
    if (selectedPayment) {
      bookingData.payment = selectedPayment.value;
    }

    // Show summary
    document.getElementById("summaryDate").textContent = bookingData.date;
    document.getElementById("summaryTime").textContent = bookingData.time;
    document.getElementById("summaryDuration").textContent = bookingData.duration;
    document.getElementById("summaryPayment").textContent = bookingData.payment;

    showStep(3);
  });

  document.getElementById("finish").addEventListener("click", () => {
    console.log("Booking Data:");
    console.log("Date:", bookingData.date);
    console.log("Time:", bookingData.time);
    console.log("Duration:", bookingData.duration);
    console.log("Payment:", bookingData.payment);
    alert("Check your console. Booking data logged successfully!");
  });
