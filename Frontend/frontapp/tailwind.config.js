import { nextui } from "@nextui-org/react";

/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
        "./node_modules/@nextui-org/theme/dist/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {},
        colors: {
            'softwhite': '#E5DDD8',
            'softpink': '#A7607A',
            'darkersoftwhite': '#d9cdc5',
        }
    },
    darkMode: "class",
    plugins: [nextui()],
}

