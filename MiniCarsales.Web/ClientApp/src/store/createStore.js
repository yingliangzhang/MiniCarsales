import { createStore, applyMiddleware, compose } from 'redux'
import rootReducer from '../reducers'
import thunk from 'redux-thunk'
// import { createBrowserHistory } from 'history'
// import {routerMiddleware} from 'connected-react-router'

export default function(initialState = {}) {
    const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose
    return createStore(
        // createRootReducer(createBrowserHistory()),
        rootReducer,
        initialState,
        composeEnhancers(
            applyMiddleware(
                // routerMiddleware(history),
                thunk
            )
        )
    )
}