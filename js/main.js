// ===========================
// MODAL FUNCTIONALITY
// ===========================

const signInBtn = document.getElementById('sign-in-btn');
const signInModal = document.getElementById('signInModal');
const closeBtn = document.querySelector('.close');

if (signInBtn) {
  signInBtn.addEventListener('click', (e) => {
    e.preventDefault();
    signInModal.classList.add('active');
  });
}

if (closeBtn) {
  closeBtn.addEventListener('click', () => {
    signInModal.classList.remove('active');
  });
}

window.addEventListener('click', (e) => {
  if (e.target === signInModal) {
    signInModal.classList.remove('active');
  }
});

// ===========================
// MOOD SELECTION
// ===========================

function selectMood(mood) {
  // Store selected mood in session
  sessionStorage.setItem('selectedMood', mood);
  // Redirect to browse page
  window.location.href = 'browse.html';
}

// ===========================
// FAVORITES FUNCTIONALITY
// ===========================

function toggleFavorite(element) {
  if (element.textContent.includes('❤️')) {
    element.textContent = '🤍';
  } else {
    element.textContent = '❤️';
  }
}

function removeFavorite(button) {
  const favItem = button.closest('.favorite-item');
  if (favItem) {
    favItem.style.opacity = '0.5';
    setTimeout(() => {
      favItem.remove();
    }, 300);
  }
}

// ===========================
// ACCOUNT PAGE TABS
// ===========================

function switchTab(tabName) {
  // Hide all tabs
  const tabs = document.querySelectorAll('.account-tab');
  tabs.forEach((tab) => tab.classList.remove('active'));

  // Remove active class from nav items
  const navItems = document.querySelectorAll('.nav-item');
  navItems.forEach((item) => item.classList.remove('active'));

  // Show selected tab
  const selectedTab = document.getElementById(tabName);
  if (selectedTab) {
    selectedTab.classList.add('active');
  }

  // Add active class to clicked nav item
  event.target.classList.add('active');
}

// ===========================
// PARTNER DASHBOARD TABS
// ===========================

function switchPartnerTab(tabName) {
  // Hide all tabs
  const tabs = document.querySelectorAll('.partner-tab');
  tabs.forEach((tab) => tab.classList.remove('active'));

  // Remove active class from nav items
  const navItems = document.querySelectorAll('.partner-nav-item');
  navItems.forEach((item) => item.classList.remove('active'));

  // Show selected tab
  const selectedTab = document.getElementById(tabName);
  if (selectedTab) {
    selectedTab.classList.add('active');
  }

  // Add active class to clicked nav item
  event.target.classList.add('active');
}

// ===========================
// NAVIGATION
// ===========================

function goToRestaurant(restaurantId) {
  // Store selected restaurant
  sessionStorage.setItem('selectedRestaurant', restaurantId);
  // Redirect to restaurant profile
  window.location.href = 'restaurant-profile.html';
}

function goToPartnerSignup() {
  window.location.href = 'partner-dashboard.html';
}

function openGoogleMaps() {
  // Open Google Maps (would use real API in production)
  window.open('https://www.google.com/maps', '_blank');
}

function openWebsite() {
  // Open restaurant website (would use real URL in production)
  window.open('https://example.com', '_blank');
}

function bookTable() {
  // Open booking platform (would integrate with OpenTable, etc.)
  window.open('https://www.opentable.com', '_blank');
}

// ===========================
// PARTNER PRICING
// ===========================

function scrollToPlans() {
  const plansSection = document.getElementById('plans');
  if (plansSection) {
    plansSection.scrollIntoView({ behavior: 'smooth' });
  }
}

// ===========================
// EDIT PROFILE
// ===========================

function editProfile() {
  // Switch to preferences tab
  switchTab('preferences');
}

function changePassword() {
  // Show password change form
  alert('Password change form would appear here');
}

// ===========================
// FILTER FUNCTIONALITY
// ===========================

document.addEventListener('DOMContentLoaded', () => {
  // Initialize filter listeners
  const filterDropdowns = document.querySelectorAll('.filter-dropdown');
  filterDropdowns.forEach((dropdown) => {
    dropdown.addEventListener('change', () => {
      console.log('Filter changed:', dropdown.value);
      // In production, would trigger API call to filter results
    });
  });

  // Initialize view toggle
  const mapToggle = document.getElementById('mapToggle');
  if (mapToggle) {
    mapToggle.addEventListener('click', () => {
      if (mapToggle.textContent === 'Map View') {
        mapToggle.textContent = 'List View';
        // Switch to map view
      } else {
        mapToggle.textContent = 'Map View';
        // Switch to list view
      }
    });
  }

  // Initialize load more
  const loadMoreBtn = document.querySelector('.load-more .secondary-button');
  if (loadMoreBtn) {
    loadMoreBtn.addEventListener('click', () => {
      console.log('Loading more results...');
      // In production, would load more results via API
    });
  }

  // Initialize form submissions
  const forms = document.querySelectorAll('form');
  forms.forEach((form) => {
    form.addEventListener('submit', (e) => {
      e.preventDefault();
      console.log('Form submitted');
      // In production, would send to backend
    });
  });
});

// ===========================
// SMOOTH SCROLLING
// ===========================

document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
  anchor.addEventListener('click', function (e) {
    const href = this.getAttribute('href');
    if (href !== '#') {
      e.preventDefault();
      const target = document.querySelector(href);
      if (target) {
        target.scrollIntoView({
          behavior: 'smooth',
        });
      }
    }
  });
});

// ===========================
// UTILITY FUNCTIONS
// ===========================

// Store user data (in production, would use backend)
function saveUserData(key, value) {
  localStorage.setItem(key, JSON.stringify(value));
}

// Retrieve user data
function getUserData(key) {
  const data = localStorage.getItem(key);
  return data ? JSON.parse(data) : null;
}

// Format currency
function formatCurrency(amount) {
  return new Intl.NumberFormat('en-CA', {
    style: 'currency',
    currency: 'CAD',
  }).format(amount);
}

// ===========================
// PARTNER MENU DROPDOWN
// ===========================

const partnerMenuBtn = document.getElementById('partner-menu-btn');
if (partnerMenuBtn) {
  partnerMenuBtn.addEventListener('click', () => {
    console.log('Partner menu clicked');
    // Would show dropdown menu in production
  });
}

// ===========================
// ANALYTICS (MOCK)
// ===========================

// Example analytics data structure (would come from backend in production)
const analyticsData = {
  views: [100, 120, 115, 130, 140, 150, 160, 175, 180, 195, 200, 210],
  clicks: [10, 15, 12, 18, 20, 22, 25, 28, 30, 32, 35, 38],
  favorites: [5, 8, 7, 10, 12, 14, 16, 18, 20, 22, 25, 27],
  moods: {
    romantic: 42,
    celebrate: 28,
    trendy: 18,
    other: 12,
  },
};

// ===========================
// RESPONSIVE NAVBAR
// ===========================

// Close modal when pressing Escape
document.addEventListener('keydown', (e) => {
  if (e.key === 'Escape') {
    const modal = document.getElementById('signInModal');
    if (modal && modal.classList.contains('active')) {
      modal.classList.remove('active');
    }
  }
});

// ===========================
// PAGE INITIALIZATION
// ===========================

console.log('Nibble - Mood-based restaurant discovery platform');
console.log('Ready to serve! 🍽️');
