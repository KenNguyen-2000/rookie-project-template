import React from 'react'
import Header from '../ui/Header'

type CommonLayoutProps = {
    children: React.ReactNode
}

const CommonLayout = ({children} : CommonLayoutProps) => {
  return (
    <div>
        <Header />
        <main>
            {children}
        </main>
    </div>
  )
}

export default CommonLayout