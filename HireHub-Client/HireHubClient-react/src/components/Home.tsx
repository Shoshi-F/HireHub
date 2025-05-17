import React from "react";
import { Link } from "react-router-dom";

const Home: React.FC = () => {
  return (
    <section className="p-8 bg-gray-100 min-h-screen">
      <h1 className="text-3xl font-semibold text-gray-800 mb-4">
        ברוכה הבאה לפורטל הגיוס שלנו
      </h1>
      <p className="text-gray-600 mb-6">
        כאן תוכלי להעלות קורות חיים, לעדכן פרטים ולגשת לפרופיל האישי שלך.
      </p>
      <Link
        to="/upload"
        className="inline-block bg-indigo-600 text-white px-5 py-2 rounded hover:bg-indigo-700"
      >
        התחילי עכשיו
      </Link>
    </section>
  );
};

export default Home;
