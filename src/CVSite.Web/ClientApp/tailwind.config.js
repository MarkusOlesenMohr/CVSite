/* eslint-env node */
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "../Pages/**/*.cshtml",
    "../Views/**/*.cshtml",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
