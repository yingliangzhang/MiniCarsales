import React from 'react';
import { Alert } from 'reactstrap';
import { connect } from 'react-redux'
import PropTypes from 'prop-types'

class AppAlert extends React.Component {
    state = {
        visible: true
    }

    onDismiss = () => {
        this.setState({ visible: false })
    }

    render() {
        const { show, color, message } = this.props
        const { visible } = this.state

        if (show) {
            return <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <Alert color={color} isOpen={visible} toggle={this.onDismiss}>
                            {message}
                        </Alert>
                    </div>
                </div>
            </div>    
        }

        return null
    }
}

AppAlert.propTypes = {
    show: PropTypes.bool,
    color: PropTypes.string,
    message: PropTypes.string,
}

const mapStateToProps = state => ({
    show: state.alert.show,
    color: state.alert.color,
    message: state.alert.message,
})

export default connect(
    mapStateToProps,
    {}
)(AppAlert)