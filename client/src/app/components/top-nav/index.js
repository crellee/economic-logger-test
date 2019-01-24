import React, { Component } from 'react';
import { NavLink } from 'react-router-dom'
export default class TopNav extends Component {
    render() {
        return (
            <header>
                <nav className="navbar navbar-expand navbar-dark fixed-top bg-dark">
                    <NavLink className="navbar-brand" to="/">Timelogger</NavLink>
                    <NavLink className="nav-link" to="/">Home</NavLink>
                    <NavLink className="nav-link" to="/test">Test</NavLink>
                </nav>
            </header>
        )
    }
}