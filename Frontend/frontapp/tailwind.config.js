import { nextui } from "@nextui-org/react";

/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
        "./node_modules/@nextui-org/theme/dist/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {}
    },
    plugins: [nextui({
        themes: {
            light: {
                colors: {
                    primary: '#FFFAFA',
                    success: '#8DA87A',
                    green: '#8DA87A',
                    softgreen: '#EFFFE5',
                    boldgreen: '#6E9857',
                    softpink: '#A7607A',
                    softwhite: '#E5DDD8',
                    softblue: '#1a8fff'
                }
            }
        }
    })],
}

