import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, password, timestamp }) => (
    <li>
        <strong>{login}</strong> attempted login at {timestamp} with password: {password}
    </li>
);

const LoginAttemptList = ({ attempts }) => {
    const [filter, setFilter] = useState('');

    const filteredAttempts = attempts.filter(attempt =>
        attempt.login.toLowerCase().includes(filter.toLowerCase())
    );

    return (
        <div className="Attempt-List-Main">
            <p>Recent activity</p>
            <input
                type="text"
                placeholder="Filter by name..."
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
            />
            <ul className="Attempt-List">
                {filteredAttempts.map((attempt, index) => (
                    <LoginAttempt
                        key={index}
                        login={attempt.login}
                        password={attempt.password}
                        timestamp={attempt.timestamp}
                    />
                ))}
            </ul>
        </div>
    );
};

export default LoginAttemptList;
