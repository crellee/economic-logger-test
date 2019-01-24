import React from 'react'
import Projects from './views/Projects'
import Test from './views/Test'
import TopNav from './components/top-nav'
import { BrowserRouter, Switch, Route } from "react-router-dom"
import './style.css'

class App extends React.Component {
    render() {
        return (
            <BrowserRouter>
                <React.Fragment>
                    <TopNav />
                    
                    <main>
                        <div className="container">
                            <Switch>
                                <Route exact path='/' component={Projects}/>
                                <Route exact path='/test' component={Test}/>
                            </Switch>
                        </div>
                    </main>
                </React.Fragment>
            </BrowserRouter>
        );
    }
}

export default App;
