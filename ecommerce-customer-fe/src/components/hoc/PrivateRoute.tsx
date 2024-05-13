import React, { useEffect, useState } from 'react'
import Cookies from 'js-cookie'
import { useNavigate } from 'react-router-dom';

const PrivateRoute = ({children}:{children: React.ReactNode}) => {
  const [authState, setAuthState] = useState(false)
  const navigate = useNavigate();
  useEffect(() => {
    const token = Cookies.get('ecommerce-token')

    if(token)
      {
        setAuthState(true)
      }else
      {
        navigate('/login')
      }
  },[])
  return authState ? (
    <>{children}</>
  ) : null
}

export default PrivateRoute