import React from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router-dom'
import { fetchCars } from '../../actions/car/fetchCars'
import PropTypes from 'prop-types'
import { Spinner } from 'reactstrap'
import CarCard from './CarCard' 

export class Cars extends React.Component {
    componentDidMount() {
        const {
            fetchCars,
        } = this.props

        fetchCars()
    }

    render() {
        const { fetchingCars, cars } = this.props

        if (fetchingCars) {
            return <Spinner type="grow" color="primary" />
        } else {
            return(
                <div className="container">
                    <div className="row">
                        <div className="col-md-12">
                            <h1 className="text-center">All Cars</h1>
                        </div>
                    </div>
                    <div className="row">
                        {
                            cars.map(car => (
                                <div className="col-md-4" key={car.id}>
                                    <CarCard car={car}/>
                                </div>)
                            )
                        }
                    </div>
                </div>
            )
        }
    }
}

Cars.propTypes = {
    fetchingCars: PropTypes.bool,
    cars: PropTypes.array,
}

const mapStateToProps = state => ({
    fetchingCars: state.car.fetchingCars,
    cars: state.car.cars
})

const mapDispatchToProps = {
    fetchCars
}

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps
)(Cars))