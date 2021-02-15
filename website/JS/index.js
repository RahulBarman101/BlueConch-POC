const circle1 = document.getElementById('circle1');
const circle2 = document.getElementById('circle2');
const circle3 = document.getElementById('circle3');
const slide1 = document.getElementById('ad-slide1');
const slide2 = document.getElementById('ad-slide2');
const slide3 = document.getElementById('ad-slide3');
const slide1_img = document.getElementById('ad-slide1-img');
const slide2_img = document.getElementById('ad-slide2-img');
const slide3_img = document.getElementById('ad-slide3-img');


circle1.addEventListener('click', () => {
    circle1.classList.add('active-circle');
    slide1.classList.remove('ad-wrapper');
    slide1_img.classList.remove('ad-wrapper');
    if (slide3.classList.contains('ad-wrapper') == false) {
        slide3.classList.add('ad-wrapper');
    }

    if (slide2.classList.contains('ad-wrapper') == false) {
        slide2.classList.add('ad-wrapper');
    }

    if (slide2_img.classList.contains('ad-wrapper') == false) {
        slide2_img.classList.add('ad-wrapper');
    }

    if (slide3_img.classList.contains('ad-wrapper') == false) {
        slide3_img.classList.add('ad-wrapper');
    }

    circle2.classList.remove('active-circle');
    circle3.classList.remove('active-circle');
})

circle2.addEventListener('click', () => {
    circle2.classList.add('active-circle');
    slide2.classList.remove('ad-wrapper');
    slide2_img.classList.remove('ad-wrapper');
    if (slide3.classList.contains('ad-wrapper') == false) {
        slide3.classList.add('ad-wrapper');
    }

    if (slide1.classList.contains('ad-wrapper') == false) {
        slide1.classList.add('ad-wrapper');
    }

    if (slide1_img.classList.contains('ad-wrapper') == false) {
        slide1_img.classList.add('ad-wrapper');
    }

    if (slide3_img.classList.contains('ad-wrapper') == false) {
        slide3_img.classList.add('ad-wrapper');
    }
    circle1.classList.remove('active-circle');
    circle3.classList.remove('active-circle');
})

circle3.addEventListener('click', () => {
    circle3.classList.add('active-circle');
    slide3.classList.remove('ad-wrapper');
    slide3_img.classList.remove('ad-wrapper');
    if (slide1.classList.contains('ad-wrapper') == false ) {
        slide1.classList.add('ad-wrapper');
    }

    if (slide2.classList.contains('ad-wrapper') == false) {
        slide2.classList.add('ad-wrapper');
    }

    if (slide2_img.classList.contains('ad-wrapper') == false) {
        slide2_img.classList.add('ad-wrapper');
    }

    if (slide1_img.classList.contains('ad-wrapper') == false) {
        slide1_img.classList.add('ad-wrapper');
    }
    circle2.classList.remove('active-circle');
    circle1.classList.remove('active-circle');
})

$(document).ready(function () {
    'use strict';
    $('.num').click(function () {
        'use strict';
        $('.num').removeClass('selected-page');
        $(this).addClass('selected-page');
    });
});

const createBoundary = () => {
    const b = document.createElement('div');
    b.classList.add('selected');
    return b;
}

$(document).ready(function () {
    'use strict';
    $('.color').click(function () {
        'use strict';
        $('.color').empty();
        $(this).append(createBoundary());
    });
});
